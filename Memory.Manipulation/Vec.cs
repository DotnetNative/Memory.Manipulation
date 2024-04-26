namespace Memory;
[StructLayout(LayoutKind.Sequential)]
public unsafe record struct Vec<T, T1>
        where T : unmanaged
        where T1 : unmanaged
{
    public Vec(T _0, T1 _1)
    {
        this._0 = _0;
        this._1 = _1;
    }

    public T _0;
    public T1 _1;

    public static implicit operator Vec<T, T1>((T a0, T1 a1) a) => new(a.a0, a.a1);
    public static implicit operator Vec<T, T1>(Vec<T, T1>* a) => new(a->_0, a->_1);
    public static implicit operator (T a0, T1 a1)(Vec<T, T1> a) => (a._0, a._1);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe record struct Vec<T, T1, T2>
        where T : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
{
    public Vec(T _0, T1 _1, T2 _2)
    {
        this._0 = _0;
        this._1 = _1;
        this._2 = _2;
    }

    public T _0;
    public T1 _1;
    public T2 _2;

    public static implicit operator Vec<T, T1, T2>((T a0, T1 a1, T2 a2) a) => new(a.a0, a.a1, a.a2);
    public static implicit operator Vec<T, T1, T2>(Vec<T, T1, T2>* a) => new(a->_0, a->_1, a->_2);
    public static implicit operator (T a0, T1 a1, T2 a2)(Vec<T, T1, T2> a) => (a._0, a._1, a._2);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe record struct Vec<T, T1, T2, T3>
        where T : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
{
    public Vec(T _0, T1 _1, T2 _2, T3 _3)
    {
        this._0 = _0;
        this._1 = _1;
        this._2 = _2;
        this._3 = _3;
    }

    public T _0;
    public T1 _1;
    public T2 _2;
    public T3 _3;

    public static implicit operator Vec<T, T1, T2, T3>((T a0, T1 a1, T2 a2, T3 a3) a) => new(a.a0, a.a1, a.a2, a.a3);
    public static implicit operator Vec<T, T1, T2, T3>(Vec<T, T1, T2, T3>* a) => new(a->_0, a->_1, a->_2, a->_3);
    public static implicit operator (T a0, T1 a1, T2 a2, T3 a3)(Vec<T, T1, T2, T3> a) => (a._0, a._1, a._2, a._3);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe record struct Vec<T, T1, T2, T3, T4>
        where T : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
{
    public Vec(T _0, T1 _1, T2 _2, T3 _3, T4 _4)
    {
        this._0 = _0;
        this._1 = _1;
        this._2 = _2;
        this._3 = _3;
        this._4 = _4;
    }

    public T _0;
    public T1 _1;
    public T2 _2;
    public T3 _3;
    public T4 _4;

    public static implicit operator Vec<T, T1, T2, T3, T4>((T a0, T1 a1, T2 a2, T3 a3, T4 a4) a) => new(a.a0, a.a1, a.a2, a.a3, a.a4);
    public static implicit operator Vec<T, T1, T2, T3, T4>(Vec<T, T1, T2, T3, T4>* a) => new(a->_0, a->_1, a->_2, a->_3, a->_4);
    public static implicit operator (T a0, T1 a1, T2 a2, T3 a3, T4 a4)(Vec<T, T1, T2, T3, T4> a) => (a._0, a._1, a._2, a._3, a._4);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe record struct Vec<T, T1, T2, T3, T4, T5>
        where T : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
{
    public Vec(T _0, T1 _1, T2 _2, T3 _3, T4 _4, T5 _5)
    {
        this._0 = _0;
        this._1 = _1;
        this._2 = _2;
        this._3 = _3;
        this._5 = _5;
    }

    public T _0;
    public T1 _1;
    public T2 _2;
    public T3 _3;
    public T4 _4;
    public T5 _5;

    public static implicit operator Vec<T, T1, T2, T3, T4, T5>((T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5) a) => new(a.a0, a.a1, a.a2, a.a3, a.a4, a.a5);
    public static implicit operator Vec<T, T1, T2, T3, T4, T5>(Vec<T, T1, T2, T3, T4, T5>* a) => new(a->_0, a->_1, a->_2, a->_3, a->_4, a->_5);
    public static implicit operator (T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)(Vec<T, T1, T2, T3, T4, T5> a) => (a._0, a._1, a._2, a._3, a._4, a._5);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe record struct Vec<T, T1, T2, T3, T4, T5, T6>
        where T : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
{
    public Vec(T _0, T1 _1, T2 _2, T3 _3, T4 _4, T5 _5, T6 _6)
    {
        this._0 = _0;
        this._1 = _1;
        this._2 = _2;
        this._3 = _3;
        this._5 = _5;
        this._6 = _6;
    }

    public T _0;
    public T1 _1;
    public T2 _2;
    public T3 _3;
    public T4 _4;
    public T5 _5;
    public T6 _6;

    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6>((T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6) a) => new(a.a0, a.a1, a.a2, a.a3, a.a4, a.a5, a.a6);
    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6>(Vec<T, T1, T2, T3, T4, T5, T6>* a) => new(a->_0, a->_1, a->_2, a->_3, a->_4, a->_5, a->_6);
    public static implicit operator (T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6)(Vec<T, T1, T2, T3, T4, T5, T6> a) => (a._0, a._1, a._2, a._3, a._4, a._5, a._6);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe record struct Vec<T, T1, T2, T3, T4, T5, T6, T7>
        where T : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
{
    public Vec(T _0, T1 _1, T2 _2, T3 _3, T4 _4, T5 _5, T6 _6, T7 _7)
    {
        this._0 = _0;
        this._1 = _1;
        this._2 = _2;
        this._3 = _3;
        this._5 = _5;
        this._6 = _6;
        this._7 = _7;
    }

    public T _0;
    public T1 _1;
    public T2 _2;
    public T3 _3;
    public T4 _4;
    public T5 _5;
    public T6 _6;
    public T7 _7;

    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7>((T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7) a) => new(a.a0, a.a1, a.a2, a.a3, a.a4, a.a5, a.a6, a.a7);
    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7>(Vec<T, T1, T2, T3, T4, T5, T6, T7>* a) => new(a->_0, a->_1, a->_2, a->_3, a->_4, a->_5, a->_6, a->_7);
    public static implicit operator (T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7)(Vec<T, T1, T2, T3, T4, T5, T6, T7> a) => (a._0, a._1, a._2, a._3, a._4, a._5, a._6, a._7);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe record struct Vec<T, T1, T2, T3, T4, T5, T6, T7, T8>
        where T : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
{
    public Vec(T _0, T1 _1, T2 _2, T3 _3, T4 _4, T5 _5, T6 _6, T7 _7, T8 _8)
    {
        this._0 = _0;
        this._1 = _1;
        this._2 = _2;
        this._3 = _3;
        this._5 = _5;
        this._6 = _6;
        this._7 = _7;
        this._8 = _8;
    }

    public T _0;
    public T1 _1;
    public T2 _2;
    public T3 _3;
    public T4 _4;
    public T5 _5;
    public T6 _6;
    public T7 _7;
    public T8 _8;

    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8>((T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8) a) => new(a.a0, a.a1, a.a2, a.a3, a.a4, a.a5, a.a6, a.a7, a.a8);
    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8>(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8>* a) => new(a->_0, a->_1, a->_2, a->_3, a->_4, a->_5, a->_6, a->_7, a->_8);
    public static implicit operator (T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8)(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8> a) => (a._0, a._1, a._2, a._3, a._4, a._5, a._6, a._7, a._8);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe record struct Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>
        where T : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
{
    public Vec(T _0, T1 _1, T2 _2, T3 _3, T4 _4, T5 _5, T6 _6, T7 _7, T8 _8, T9 _9)
    {
        this._0 = _0;
        this._1 = _1;
        this._2 = _2;
        this._3 = _3;
        this._5 = _5;
        this._6 = _6;
        this._7 = _7;
        this._8 = _8;
        this._9 = _9;
    }

    public T _0;
    public T1 _1;
    public T2 _2;
    public T3 _3;
    public T4 _4;
    public T5 _5;
    public T6 _6;
    public T7 _7;
    public T8 _8;
    public T9 _9;

    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>((T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9) a) => new(a.a0, a.a1, a.a2, a.a3, a.a4, a.a5, a.a6, a.a7, a.a8, a.a9);
    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>* a) => new(a->_0, a->_1, a->_2, a->_3, a->_4, a->_5, a->_6, a->_7, a->_8, a->_9);
    public static implicit operator (T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9)(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9> a) => (a._0, a._1, a._2, a._3, a._4, a._5, a._6, a._7, a._8, a._9);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe record struct Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        where T : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
        where T10 : unmanaged
{
    public Vec(T _0, T1 _1, T2 _2, T3 _3, T4 _4, T5 _5, T6 _6, T7 _7, T8 _8, T9 _9, T10 _10)
    {
        this._0 = _0;
        this._1 = _1;
        this._2 = _2;
        this._3 = _3;
        this._5 = _5;
        this._6 = _6;
        this._7 = _7;
        this._8 = _8;
        this._9 = _9;
        this._10 = _10;
    }

    public T _0;
    public T1 _1;
    public T2 _2;
    public T3 _3;
    public T4 _4;
    public T5 _5;
    public T6 _6;
    public T7 _7;
    public T8 _8;
    public T9 _9;
    public T10 _10;

    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>((T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10) a) => new(a.a0, a.a1, a.a2, a.a3, a.a4, a.a5, a.a6, a.a7, a.a8, a.a9, a.a10);
    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>* a) => new(a->_0, a->_1, a->_2, a->_3, a->_4, a->_5, a->_6, a->_7, a->_8, a->_9, a->_10);
    public static implicit operator (T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10)(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> a) => (a._0, a._1, a._2, a._3, a._4, a._5, a._6, a._7, a._8, a._9, a._10);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe record struct Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
        where T : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
        where T10 : unmanaged
        where T11 : unmanaged
{
    public Vec(T _0, T1 _1, T2 _2, T3 _3, T4 _4, T5 _5, T6 _6, T7 _7, T8 _8, T9 _9, T10 _10, T11 _11)
    {
        this._0 = _0;
        this._1 = _1;
        this._2 = _2;
        this._3 = _3;
        this._5 = _5;
        this._6 = _6;
        this._7 = _7;
        this._8 = _8;
        this._9 = _9;
        this._10 = _10;
        this._11 = _11;
    }

    public T _0;
    public T1 _1;
    public T2 _2;
    public T3 _3;
    public T4 _4;
    public T5 _5;
    public T6 _6;
    public T7 _7;
    public T8 _8;
    public T9 _9;
    public T10 _10;
    public T11 _11;

    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>((T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11) a) => new(a.a0, a.a1, a.a2, a.a3, a.a4, a.a5, a.a6, a.a7, a.a8, a.a9, a.a10, a.a11);
    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>* a) => new(a->_0, a->_1, a->_2, a->_3, a->_4, a->_5, a->_6, a->_7, a->_8, a->_9, a->_10, a->_11);
    public static implicit operator (T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11)(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> a) => (a._0, a._1, a._2, a._3, a._4, a._5, a._6, a._7, a._8, a._9, a._10, a._11);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe record struct Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
        where T : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
        where T10 : unmanaged
        where T11 : unmanaged
        where T12 : unmanaged
{
    public Vec(T _0, T1 _1, T2 _2, T3 _3, T4 _4, T5 _5, T6 _6, T7 _7, T8 _8, T9 _9, T10 _10, T11 _11, T12 _12)
    {
        this._0 = _0;
        this._1 = _1;
        this._2 = _2;
        this._3 = _3;
        this._5 = _5;
        this._6 = _6;
        this._7 = _7;
        this._8 = _8;
        this._9 = _9;
        this._10 = _10;
        this._11 = _11;
        this._12 = _12;
    }

    public T _0;
    public T1 _1;
    public T2 _2;
    public T3 _3;
    public T4 _4;
    public T5 _5;
    public T6 _6;
    public T7 _7;
    public T8 _8;
    public T9 _9;
    public T10 _10;
    public T11 _11;
    public T12 _12;

    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>((T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12) a) => new(a.a0, a.a1, a.a2, a.a3, a.a4, a.a5, a.a6, a.a7, a.a8, a.a9, a.a10, a.a11, a.a12);
    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>* a) => new(a->_0, a->_1, a->_2, a->_3, a->_4, a->_5, a->_6, a->_7, a->_8, a->_9, a->_10, a->_11, a->_12);
    public static implicit operator (T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12)(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> a) => (a._0, a._1, a._2, a._3, a._4, a._5, a._6, a._7, a._8, a._9, a._10, a._11, a._12);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe record struct Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
        where T : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
        where T10 : unmanaged
        where T11 : unmanaged
        where T12 : unmanaged
        where T13 : unmanaged
{
    public Vec(T _0, T1 _1, T2 _2, T3 _3, T4 _4, T5 _5, T6 _6, T7 _7, T8 _8, T9 _9, T10 _10, T11 _11, T12 _12, T13 _13)
    {
        this._0 = _0;
        this._1 = _1;
        this._2 = _2;
        this._3 = _3;
        this._5 = _5;
        this._6 = _6;
        this._7 = _7;
        this._8 = _8;
        this._9 = _9;
        this._10 = _10;
        this._11 = _11;
        this._12 = _12;
        this._13 = _13;
    }

    public T _0;
    public T1 _1;
    public T2 _2;
    public T3 _3;
    public T4 _4;
    public T5 _5;
    public T6 _6;
    public T7 _7;
    public T8 _8;
    public T9 _9;
    public T10 _10;
    public T11 _11;
    public T12 _12;
    public T13 _13;

    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>((T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13) a) => new(a.a0, a.a1, a.a2, a.a3, a.a4, a.a5, a.a6, a.a7, a.a8, a.a9, a.a10, a.a11, a.a12, a.a13);
    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>* a) => new(a->_0, a->_1, a->_2, a->_3, a->_4, a->_5, a->_6, a->_7, a->_8, a->_9, a->_10, a->_11, a->_12, a->_13);
    public static implicit operator (T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13)(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> a) => (a._0, a._1, a._2, a._3, a._4, a._5, a._6, a._7, a._8, a._9, a._10, a._11, a._12, a._13);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe record struct Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
        where T : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
        where T10 : unmanaged
        where T11 : unmanaged
        where T12 : unmanaged
        where T13 : unmanaged
        where T14 : unmanaged
{
    public Vec(T _0, T1 _1, T2 _2, T3 _3, T4 _4, T5 _5, T6 _6, T7 _7, T8 _8, T9 _9, T10 _10, T11 _11, T12 _12, T13 _13, T14 _14)
    {
        this._0 = _0;
        this._1 = _1;
        this._2 = _2;
        this._3 = _3;
        this._5 = _5;
        this._6 = _6;
        this._7 = _7;
        this._8 = _8;
        this._9 = _9;
        this._10 = _10;
        this._11 = _11;
        this._12 = _12;
        this._13 = _13;
        this._14 = _14;
    }

    public T _0;
    public T1 _1;
    public T2 _2;
    public T3 _3;
    public T4 _4;
    public T5 _5;
    public T6 _6;
    public T7 _7;
    public T8 _8;
    public T9 _9;
    public T10 _10;
    public T11 _11;
    public T12 _12;
    public T13 _13;
    public T14 _14;

    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>((T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14) a) => new(a.a0, a.a1, a.a2, a.a3, a.a4, a.a5, a.a6, a.a7, a.a8, a.a9, a.a10, a.a11, a.a12, a.a13, a.a14);
    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>* a) => new(a->_0, a->_1, a->_2, a->_3, a->_4, a->_5, a->_6, a->_7, a->_8, a->_9, a->_10, a->_11, a->_12, a->_13, a->_14);
    public static implicit operator (T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14)(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> a) => (a._0, a._1, a._2, a._3, a._4, a._5, a._6, a._7, a._8, a._9, a._10, a._11, a._12, a._13, a._14);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe record struct Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
        where T : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
        where T10 : unmanaged
        where T11 : unmanaged
        where T12 : unmanaged
        where T13 : unmanaged
        where T14 : unmanaged
        where T15 : unmanaged
{
    public Vec(T _0, T1 _1, T2 _2, T3 _3, T4 _4, T5 _5, T6 _6, T7 _7, T8 _8, T9 _9, T10 _10, T11 _11, T12 _12, T13 _13, T14 _14, T15 _15)
    {
        this._0 = _0;
        this._1 = _1;
        this._2 = _2;
        this._3 = _3;
        this._5 = _5;
        this._6 = _6;
        this._7 = _7;
        this._8 = _8;
        this._9 = _9;
        this._10 = _10;
        this._11 = _11;
        this._12 = _12;
        this._13 = _13;
        this._14 = _14;
        this._15 = _15;
    }

    public T _0;
    public T1 _1;
    public T2 _2;
    public T3 _3;
    public T4 _4;
    public T5 _5;
    public T6 _6;
    public T7 _7;
    public T8 _8;
    public T9 _9;
    public T10 _10;
    public T11 _11;
    public T12 _12;
    public T13 _13;
    public T14 _14;
    public T15 _15;

    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>((T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15) a) => new(a.a0, a.a1, a.a2, a.a3, a.a4, a.a5, a.a6, a.a7, a.a8, a.a9, a.a10, a.a11, a.a12, a.a13, a.a14, a.a15);
    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>* a) => new(a->_0, a->_1, a->_2, a->_3, a->_4, a->_5, a->_6, a->_7, a->_8, a->_9, a->_10, a->_11, a->_12, a->_13, a->_14, a->_15);
    public static implicit operator (T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15)(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> a) => (a._0, a._1, a._2, a._3, a._4, a._5, a._6, a._7, a._8, a._9, a._10, a._11, a._12, a._13, a._14, a._15);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe record struct Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
        where T : unmanaged
        where T1 : unmanaged
        where T2 : unmanaged
        where T3 : unmanaged
        where T4 : unmanaged
        where T5 : unmanaged
        where T6 : unmanaged
        where T7 : unmanaged
        where T8 : unmanaged
        where T9 : unmanaged
        where T10 : unmanaged
        where T11 : unmanaged
        where T12 : unmanaged
        where T13 : unmanaged
        where T14 : unmanaged
        where T15 : unmanaged
        where T16 : unmanaged
{
    public Vec(T _0, T1 _1, T2 _2, T3 _3, T4 _4, T5 _5, T6 _6, T7 _7, T8 _8, T9 _9, T10 _10, T11 _11, T12 _12, T13 _13, T14 _14, T15 _15, T16 _16)
    {
        this._0 = _0;
        this._1 = _1;
        this._2 = _2;
        this._3 = _3;
        this._5 = _5;
        this._6 = _6;
        this._7 = _7;
        this._8 = _8;
        this._9 = _9;
        this._10 = _10;
        this._11 = _11;
        this._12 = _12;
        this._13 = _13;
        this._14 = _14;
        this._15 = _15;
        this._16 = _16;
    }

    public T _0;
    public T1 _1;
    public T2 _2;
    public T3 _3;
    public T4 _4;
    public T5 _5;
    public T6 _6;
    public T7 _7;
    public T8 _8;
    public T9 _9;
    public T10 _10;
    public T11 _11;
    public T12 _12;
    public T13 _13;
    public T14 _14;
    public T15 _15;
    public T16 _16;

    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>((T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15, T16 a16) a) => new(a.a0, a.a1, a.a2, a.a3, a.a4, a.a5, a.a6, a.a7, a.a8, a.a9, a.a10, a.a11, a.a12, a.a13, a.a14, a.a15, a.a16);
    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>* a) => new(a->_0, a->_1, a->_2, a->_3, a->_4, a->_5, a->_6, a->_7, a->_8, a->_9, a->_10, a->_11, a->_12, a->_13, a->_14, a->_15, a->_16);
    public static implicit operator (T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10, T11 a11, T12 a12, T13 a13, T14 a14, T15 a15, T16 a16)(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> a) => (a._0, a._1, a._2, a._3, a._4, a._5, a._6, a._7, a._8, a._9, a._10, a._11, a._12, a._13, a._14, a._15, a._16);
}