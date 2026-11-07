public static class Probe {
    public static void Run() {
        Console.WriteLine(">>> Проба <<<");

        Guild probeGuild = new Guild("Учебная гильдия");
        probeGuild.AddHero(new Hero("Учебный воин", 150));
        probeGuild.AddHero(new Hero("Учебный Маг", 90));

        List<Hero> copy = probeGuild.GetMember();
        copy.Clear();
        Console.WriteLine($"В копии: {copy.Count}");
        Console.WriteLine($"В гильдии: {probeGuild.MemberCount}");

        List<Hero> again = probeGuild.GetMember();
        again[0].TakeDamage(50);
        Hero? warrior = probeGuild.FindHeroByName("Учебный воин");
        if (warrior != null) {
            Console.WriteLine($"Здоровье воина в гильдии {warrior.Health}");
        }
    }
}