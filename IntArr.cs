class IntArr {

    private int[] body;

    public IntArr() {}

    public IntArr(int n) {
        body = new int[n];
    }

    public int this[int i] {
        get {
            return body[i];
        }
        set {
            body[i] = value;
        }
    }

    public int Length {
        get {
            return body.Length;
        }
    }

    public override string ToString() {
        string result = "";
        result += "[";
        for (int i = 0; i < body.Length; i++) {
            if (i == 0)
                result += $" {body[i]}";
            else
                result += $"; {body[i]}";
        }
        result += " ]";
        return result;
    }
}