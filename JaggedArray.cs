using System;

class JaggedArray<T> {

    private T[][] body;

    public JaggedArray() {
        body = new T[1][];
        // body[0] = null;
    }

    public JaggedArray(int x) {
        body = new T[x][];
        // for (int i = 0; i < x; i++) {
        //     body[i] = null;
        // }
    }

    public override string ToString() {
        string result = "";
        for (int i = 0; i < body.Length; i++) {
            if (body[i] != null) {
                for (int j = 0; j < body[i].Length; j++) {
                    result += $" {body[i][j]}";
                }
                result += "\n";
            }
        }
        return result;
    }

    private int Count {
        get {
            int c = 0;
            for (int i = 0; i < body.Length; i++)
                if (body[i] != null) c++;
            return c;
        }
    }

    public int Length {
        get {
            return body.Length;
        }
    }

    public T[] this[int i] {
        get {
            return body[i];
        }
        set {
            body[i] = value;
        }
    }

    private void Extend(T[] item, int index) {
        T[][] newbody = new T[body.Length + 1][];
        for (int i = 0; i < body.Length + 1; i++) {
            if (i < index)
                newbody[i] = body[i];
            else
            if (i > index)
                newbody[i] = body[i - 1];
            else
                newbody[i] = item;
        }
        body = newbody;
    }

    public void Insert(T[] item, int index) {

        if (body[index] == null) {
            body[index] = item;
        } else {
            Extend(item, index);
        }
    }

    public void Append(T[] item) {
        Extend(item, body.Length);
    }

    public void Prepend(T[] item) {
        Extend(item, 0);
    }

    public void Remove(int index) {
        if (body[index] != null) {
            body[index] = null;
        }
    }

    public void Clear() {
        for (int i = 0; i < body.Length; i++)
            Remove(i);
    }

    public void Sort(bool descending) {
        int minIndex = 0;
        T[] tmp;
        for (int i = 0; i < Count; i++) {
            minIndex = -1;
            for (int j = i; j < body.Length; j++) {
                if (body[j] != null) {
                    if (minIndex == -1)
                        minIndex = j;
                    else
                    if (!descending && body[j].Length < body[minIndex].Length)
                        minIndex = j;
                    else
                    if (descending && body[j].Length > body[minIndex].Length)
                        minIndex = j;
                }
            }
            tmp = body[minIndex];
            body[minIndex] = body[i];
            body[i] = tmp;
        }
    }

    public bool Contains(T item) {
        bool result = false;
        for (int i = 0; i < body.Length && !result; i++) {
            if (body[i] != null) {
                result = body[i].Contains(item);
            }
        }
        return result;
    }

    public void Reverse() {
        T[] tmp;
        for (int i = 0; i < body.Length / 2; i++) {
            tmp = body[i];
            body[i] = body[body.Length - i - 1];
            body[body.Length - i - 1] = tmp;
        }
    }

    public void FillRandom(T[] pool, int n) {
        T[] tmp;
        int l;
        for (int i = 0; i < body.Length; i++) {
            l = Rand.rnd.Next(1, n + 1);
            tmp = new T[l];
            for (int j = 0; j < l; j++) {
                tmp[j] = pool[Rand.rnd.Next(pool.Length)];
            }
            body[i] = tmp;
        }
    }
}