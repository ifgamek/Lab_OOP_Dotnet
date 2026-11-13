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

Console.WriteLine($">>> {guild.Name}: Участников {guild.MemberCount} <<<");
Console.WriteLine();
QuestBoard board = new QuestBoard(guild);

Quest floatQuest = new Quest(101, "Вернуть поплавок", 100, 30);
Console.WriteLine($"Поручение добавлено: {board.AddQuest(floatQuest)}");
Console.WriteLine($">>> №{floatQuest.Id}: {floatQuest.Title} <<<");

Console.WriteLine($"Назначение Сергея: {board.TryAssign(101, " сЕрГеЙ ")}");
Hero? assigned = floatQuest.AssingnedHero;
if (assigned != null) {
    Console.WriteLine($"Исполнитель: {assigned.Name}");
}
Console.WriteLine($"Опыт после назначения: {sergey.Experience}");

Console.WriteLine($"Завершение: {board.TryComplete(101)}");
Console.WriteLine($"Опыт после завершения: {sergey.Experience}");
Console.WriteLine($"Повторное завершение: {board.TryComplete(101)}");
Console.WriteLine($"Опыт после повтора: {sergey.Experience}");


Console.WriteLine($"Открыто {board.CountByStatus(QuestStatus.Open)} Назанчено {QuestStatus.Assingned} Отменено {QuestStatus.Cancelled} Завершено{QuestStatus.Completed}");

Console.WriteLine($"{yaroslav.Name} {board.FindActiveQuest(yaroslav.Name)}");
Console.WriteLine($"{sergey.Name} {board.FindActiveQuest(sergey.Name)}");




Console.WriteLine("\n");



Console.WriteLine("\n \n \n");




Inventory yar_inv = new Inventory("доспех", 2);
Inventory ana_inv = new Inventory("еда", 5);
Inventory art_inv = new Inventory("камень", 8);



ana_inv.Plus_i("еда", 2);
ana_inv.Plus_i("плащ", 1);
ana_inv.Plus_i("зелье", 1);

yar_inv.Drop("доспех", 1);
art_inv.Drop("камень", 4);

Console.WriteLine($"\n{yaroslav.Name}: {yar_inv.INFO_i()}");
Console.WriteLine($"{anastasia.Name}: {ana_inv.INFO_i()}");
Console.WriteLine($"{artem.Name}: {art_inv.INFO_i()}");
