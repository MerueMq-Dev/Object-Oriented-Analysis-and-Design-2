using OOAD2.Solutions;

Person owner = new("Дмитрий", 32);
List<Animal> animals = [new Dog("Шарик", owner), new Cat("Мурлытик", owner)];
foreach (Animal animal in animals)
{
    animal.Speak();
}
