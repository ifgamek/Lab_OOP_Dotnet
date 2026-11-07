public class Guild {
    public string Name { get; private set; }
    private List<Hero> _heroes = new List<Hero>();

    public int MemberCount {
        get { return _heroes.Count;  }
    }

    public Guild(string name) {
        Name = name;
    }

    public bool AddHero(Hero hero) {
        if (FindHeroByName(hero.Name) != null) {
            return false;
        }

        _heroes.Add(hero);
        return true;
    }

    public List<Hero> GetMember() {
        List<Hero> result = new List<Hero>();
        foreach (Hero hero in _heroes) {
            result.Add(hero);
        }
        return result;
    }

    public Hero? FindHeroByName(string name) {
        if (string.IsNullOrWhiteSpace(name)) {
            return null;
        }

        string searchName = name.Trim();

        foreach (Hero hero in _heroes) {
            if (string.Equals(hero.Name, searchName, StringComparison.OrdinalIgnoreCase)) {
                return hero;
            }
        }
        return null;
    }


    public bool RemoveHero(string name) {
        Hero? hero = FindHeroByName(name);
        if (hero == null) {
            return false;
        }

        return _heroes.Remove(hero);
    }
}