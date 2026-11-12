public class Quest {
    public int Id { get; private set; }
    public string Title { get; private set; }
    public int MinHealth { get; private set; }
    public int Reward { get; private set; }
    public Hero? AssingnedHero { get; private set; }
    public QuestStatus Status { get; private set; }

    public Quest(int id, string title, int minHealth, int reward) {
        Id = id;

        if (string.IsNullOrWhiteSpace(title)) {
            Title = "безымянное поручение";
        }
        else {
            Title = title.Trim();
        }

        MinHealth = minHealth;
        if (MinHealth < 0) {
            MinHealth = 0;
        }
        Reward = reward;
        if (Reward < 1) {
            Reward = 1;
        }

        AssingnedHero = null;
        Status = QuestStatus.Open;
    }

    public bool TryAssing(Hero hero) {
        if (Status != QuestStatus.Open) { return false; }
        if (!hero.IsAlive()) { return false; }
        if (hero.Health < MinHealth) { return false; }

        AssingnedHero = hero;
        Status = QuestStatus.Assingned;
        return true;
    }

    public bool TryComplete() {
        if (Status != QuestStatus.Assingned) {
            return false;
        }

        Hero? hero = AssingnedHero;
        if (hero == null) {
            return false;
        }
        if (!hero.IsAlive()) {
            return false;
        }
        if (hero.Health < MinHealth) {
            return false;
        }
        if (!hero.CanGainExperience(Reward)) {
            return false;
        }

        hero.GainExperience(Reward);
        Status = QuestStatus.Completed;
        return true;
    }

    public bool TryCancel() {
        if (Status != QuestStatus.Open && Status != QuestStatus.Assingned) {
            return false;
        }
        Status = QuestStatus.Cancelled;
        return true;

    }

    public string GetStatusText() {
        switch (Status) {
            case QuestStatus.Open: return "Открыто";
            case QuestStatus.Assingned: return "Назначено";
            case QuestStatus.Completed: return "Выполнено";
            case QuestStatus.Cancelled: return "Отменено";
            default: return "Неизвестно";
        }
    }

    public string GetInfo() {
        string heroText = "";

        if (AssingnedHero != null) {
            heroText = AssingnedHero.Name;
        }

        return $"№{Id} <<{Title}>>: {GetStatusText()}, исполнитель {heroText}";
    }
}