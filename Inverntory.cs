
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
        items.Add(str);


        if (Count <= 0) { Count = 0; }

        if (Count > 10) { Count = 10; }


    }




    public void Plus_i(string item, int plus) {
        if (plus <= 0 || string.IsNullOrWhiteSpace(item)) { return; }

        if (inv_pr.inv_Count(Count + plus)) {
            if (item.ToLower() == Name.ToLower()) {
                Count += plus;
                str = $"{Name} {Count}";
                return;
            }

            else {
                Count += plus;
                str += $" {item} {plus}";
                items.Add($"{item} {plus}");
                return;
            }

        }
    }


    public void Drop(string item, int drop) {
        if (drop <= 0 || string.IsNullOrWhiteSpace(item)) { return; }

        if (inv_pr.inv_Count(Count)) {
            if (item.ToLower() == Name.ToLower()) {
                if (drop > Count) { Count = 0; } else { Count -= drop; }
                items.Clear();
                str = $"{Name} {Count}";
                return;
            }


            for (int i = 0; i < items.Count; i++) {
                if (items[i].Contains(item)) {
                    items.RemoveAt(i);
                    break;
                }
            }
        }

    }



    public string INFO_i() {
        if (items.Count == 0) {
            items.Add(str);
        }

        if (string.IsNullOrWhiteSpace(str)) { return "Пусто"; }

        return $"Инвентарь: {str}";
    }
}