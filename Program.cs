// Probe.Run();

Console.WriteLine();
Hero yaroslav = new Hero("Ярослав", 100);
Hero anastasia = new Hero("Анастасия", 90);
Hero artem = new Hero("Артем", 120);
Hero alexander = new Hero("Александр", 150);
Hero sergey = new Hero("Сергей", 110);


alexander.TakeDamage(10);
alexander.Heal(10);

Guild guild = new Guild("Гильдия героев");

guild.Heroes.Add(yaroslav);
guild.Heroes.Add(anastasia);
guild.Heroes.Add(artem);
guild.Heroes.Add(alexander);
guild.Heroes.Add(sergey);

if (guild.Heroes.Count > 0) {
    Hero strogngest = guild.Heroes[0];
    Console.WriteLine($"Первый: {strogngest}");
    Console.WriteLine($"Последний {guild.Heroes[guild.Heroes.Count - 1].Name}");

    foreach (Hero hero in guild.Heroes) {
        if (hero.Health >= strogngest.Health) { strogngest = hero; }
    }
    Console.WriteLine($"Самый здоровый: {strogngest}");
}
Console.WriteLine();

foreach (Hero hero in guild.Heroes) {
    Console.WriteLine(hero.GetInfo());
    Console.WriteLine();
}

Console.WriteLine($">>>{guild.Name}: перекличка <<<");
Console.WriteLine($"Участники :{guild.Heroes.Count}");

int strongCount = 0;

foreach (Hero hero in guild.Heroes) {
    if (hero.Health >= 120) { strongCount++; }

}
Console.WriteLine($"Могут нест тяжелые ящики (Здоровье о  120)     {strongCount}");

Console.WriteLine("\n");



Console.WriteLine("\n \n \n");




Inventory yar_inv = new Inventory("доспех", 2);
Inventory ana_inv = new Inventory("еда", 5);
Inventory art_inv = new Inventory("камень", 8);



ana_inv.Plus_i("ЕДА", 2);
ana_inv.Plus_i("плащ", 2);
ana_inv.Plus_i("зелье", 1);

yar_inv.Drop("доспех", 1);
art_inv.Drop("камень", 4);

Console.WriteLine($"\n{yaroslav.Name}: {yar_inv.INFO_i()}");
Console.WriteLine($"{anastasia.Name}: {ana_inv.INFO_i()}");
Console.WriteLine($"{artem.Name}: {art_inv.INFO_i()}");
