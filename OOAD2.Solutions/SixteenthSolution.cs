using System.Text;

namespace OOAD2.Solutions
{
    public class SixteenthSolution
    {
        public void Show()
        {
            // HTML - конкретный тип
            var htmlBuilder = new HtmlDocumentBuilder();
            htmlBuilder
                .AddHeader("Welcome")
                .AddCss("body { margin: 0; }")
                .AddParagraph("Hello world");

            Console.WriteLine(htmlBuilder.GetContent());
            // <header><h1>Welcome</h1></header><style>body { margin: 0; }</style><p>Hello world</p>

            // Markdown - конкретный тип
            var mdBuilder = new MarkdownDocumentBuilder();
            mdBuilder
                .AddHeader("Welcome")
                .AddBold("Important text");

            Console.WriteLine(mdBuilder.GetContent());            
    
            // Полиморфное использование - теряем специфичные методы
            DocumentBuilder builder = new HtmlDocumentBuilder();
            builder.AddHeader("Title"); // Работает
            // builder.AddCss("..."); // Не скомпилируется.        
        }
    }

    public abstract class DocumentBuilder
    {
        protected StringBuilder content = new StringBuilder();

        // Абстрактный метод - каждый наследник сам решает как добавлять заголовок
        public abstract DocumentBuilder AddHeader(string header);

        public string GetContent() => content.ToString();
    }

    public class HtmlDocumentBuilder : DocumentBuilder
    {
        // Ковариантность. Возвращаем HtmlDocumentBuilder вместо DocumentBuilder
        public override HtmlDocumentBuilder AddHeader(string header)
        {
            content.Append($"<header><h1>{header}</h1></header>");
            return this;
        }

        public HtmlDocumentBuilder AddCss(string css)
        {
            content.Append($"<style>{css}</style>");
            return this;
        }

        public HtmlDocumentBuilder AddParagraph(string text)
        {
            content.Append($"<p>{text}</p>");
            return this;
        }
    }

    public class MarkdownDocumentBuilder : DocumentBuilder
    {
        // Ковариантность. Возвращаем MarkdownDocumentBuilder вместо DocumentBuilder
        public override MarkdownDocumentBuilder AddHeader(string header)
        {
            content.AppendLine($"# {header}"); // Markdown синтаксис
            return this;
        }

        public MarkdownDocumentBuilder AddBold(string text)
        {
            content.Append($"**{text}**");
            return this;
        }
    }
}
