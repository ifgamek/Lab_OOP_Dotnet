public class Inventory {

    public string _name = "Безымянный Предмет";
    public int Count { get; private set; }
    public List<string> items { get; private set; } = new List<string>();
    public string str;

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
        str = $"{Name} {Count}";


        if (Count <= 0) { Count = 0; }

        if (Count > 10) { Count = 10; }

    }




    public void Plus_i(string item, int plus) {

        if (plus <= 0) { return; }

        if (item.ToLower() == Name.ToLower()) {
            Count += plus;
        }
        else {
            str += $" {item} {plus}";
        }
    }


    public void Drop(string item, int drop) {
        if (drop <= 0) { return; }
        if (drop > Count) { Count = 0; }

        if (item.ToLower() == Name.ToLower()) {
            if (drop > Count) { Count = 0; }
            else { Count -= drop; }
        }

    }



    public string INFO_i() {
        items.Add(str);

        if (items.Count == 0) { return "Пусто"; }

        return $"Инвентарь: {string.Join(" ", items)}";
    }
}