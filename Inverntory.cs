public class Inventory {

    public string _name = "Безымянный Предмет";
    public int Count { get; private set; }

    public string Name {
        get { return _name; }

        private set {
            if (string.IsNullOrWhiteSpace(value)) {
                _name = "Безымянный Предмет";
                return;
            }

            _name = value.Trim();
        }
    }
    public Inventory(string name, int count) {
        Name = name;
        Count = count;

        if (Count <= 0) { Count = 0; }

        if (Count > 10) { Count = 10; }

    }

    public void Plus_i(int plus) {
        if (plus <= 0) { return; }

        Count += plus;
    }

    public void Drop(int drop) {
        if (drop <= 0) { return; }

        Count -= drop;
    }

    public string INFO_i() {
        return $"у данного персонажа {Count} {Name}";
    }
}