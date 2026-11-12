public static class Probe {
    public static void Run() {
        Console.WriteLine(">>> Проба <<<");

        Guild probeGuild = new Guild("Учебная гильдия");
        Hero master = new Hero("Учебный мастер", 110);
        probeGuild.AddHero(master);

        QuestBoard probeBoard = new QuestBoard(probeGuild);
        Quest probeQuest = new Quest(1, "Учебное дело", 100  , 10);
        probeBoard.AddQuest(probeQuest);

        Console.WriteLine($"Закрыть открытое: {probeBoard.TryComplete(1)}");
    Console.WriteLine($"Назначить: {probeBoard.TryAssign(1, "Учебный мастер")}");
    Console.WriteLine($"Назначить ещё раз: {probeBoard.TryAssign(1, "Учебный мастер")}");
    Console.WriteLine($"Отменить: {probeBoard.TryCancel(1)}");
    Console.WriteLine($"Закрыть отменённое: {probeBoard.TryComplete(1)}");
    Console.WriteLine($"Отменить ещё раз: {probeBoard.TryCancel(1)}");
    Console.WriteLine(probeQuest.GetInfo());
    Console.WriteLine($"Опыт: {master.Experience}");
}


}