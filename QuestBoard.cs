public class QuestBoard {
    private readonly Guild _guild;
    private readonly List<Quest> _quests = new List<Quest>();

    public QuestBoard(Guild guild) {
        _guild = guild;
    }

    public bool AddQuest(Quest quest) {
        if (quest.Status != QuestStatus.Open){
            return false;
        }
        if (FindQuest(quest.Id) != null) {
            return false;
        }
        _quests.Add(quest);
        return true;
    }

    public Quest? FindQuest(int questId) {
        foreach (Quest quest in _quests) {
            if (quest.Id == questId) {
                return quest;
            }
        }
        return null;
    }

    public bool TryAssign(int questId, string heroName) {
        Quest? quest = FindQuest(questId);
        if (quest == null) {
            return false;
        }

        Hero? hero = _guild.FindHeroByName(heroName);
        if (hero == null) {
            return false;
        }

        if (IsAssigned(hero)) {
            return false;
        }
        return quest.TryAssing(hero);
    }

    public bool TryComplete(int questId) {
        Quest? quest = FindQuest(questId);
        if (quest == null) { return false; }
        return quest.TryComplete();
    }

    public bool TryCancel(int questId) {
        Quest? quest = FindQuest(questId);
        if (quest == null) { return false; }

        return quest.TryCancel();
    }

    public List<Quest> GetQuests() {
        return new List<Quest>(_quests);
    }

    public bool IsAssigned(Hero hero) {
        foreach (Quest quest in _quests) {
            if (quest.Status == QuestStatus.Assingned && quest.AssingnedHero == hero) {
                return true;
            }
        }
        return false;
    }

    public bool TryRemoveMember(string heroName) {
        Hero? hero = _guild.FindHeroByName(heroName);
        if (hero == null) {
            return false;
        }

        foreach (Quest quest in _quests) {
            if (quest.AssingnedHero == hero) {
                return false;
            }
        }
        return _guild.RemoveHero(hero.Name);
    }

    public int CountByStatus(QuestStatus status) {
        int count = 0;
        foreach (var i in _quests) {
            if (i.Status == status) {
                count++;
            }
        }
        return count;
    }

    public Quest? FindActiveQuest(string heroName) {
         var hero = _guild.FindHeroByName(heroName);
    if (hero == null)
    {
        return null;
    }

    foreach (var quest in _quests)
    {
        if (quest.AssingnedHero == hero && quest.Status == QuestStatus.Assingned)
        {
            return quest;
        }
    }

    return null;
    }
}
