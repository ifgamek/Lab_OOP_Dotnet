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

guild.AddHero(yaroslav);
guild.AddHero(anastasia);
guild.AddHero(artem);
guild.AddHero(alexander);
guild.AddHero(sergey);
List<Hero> members = guild.GetMember();


Hero? found = guild.FindHeroByName(" аРтЁм ");
if (found != null) {
    Console.WriteLine($"Найден по запросу « аРтЁм »: {found.Name}");
} else {
    Console.WriteLine("По запросу « аРтЁм » никого нет.");
}
Console.WriteLine($"Повтор Александра принят: {guild.AddHero(alexander)}");
Console.WriteLine($"Удалён отсутствующий: {guild.RemoveHero("Борис")}");
Console.WriteLine($"Участников после проверок: {guild.MemberCount}");



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
