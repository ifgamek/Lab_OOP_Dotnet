public class Operation
{
    public int Number { get; }
    public string STR { get; }
    public Inventory inv { get; private set; }
    public bool IsStarted { get; private set; }
    public bool IsFinished { get; private set; }

    public Operation(int number, string STR)
    {
        Number = number;
        STR = STR;
    }

    public bool TryStart(Inventory inv)
    {
        if (inv == null || IsStarted || IsFinished) return false;
        if (inv.status != inv_status.Open) return false;

        inv = inv;
        IsStarted = true;
        return true;
    }

    public bool TryFinish()
    {
        if (!IsStarted || IsFinished || inv == null) return false;
        if (!ChangeStatus(inv, inv_status.Close)) return false;

        IsFinished = true;
        return true;
    }

    private static bool ChangeStatus(Inventory inv, inv_status newStatus)
    {
        if (inv == null) return false;
        if (inv.status == newStatus) return false;
        if (inv.status == inv_status.Close && newStatus == inv_status.Open && inv.Count == 0)
            return false;

        inv.ChangeStatus(newStatus);
        return true;
    }
}