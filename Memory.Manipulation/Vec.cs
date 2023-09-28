using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Manipulation;

public unsafe record struct Vec<T, T1>(T _, T1 _1)
    where T : unmanaged 
    where T1 : unmanaged
{
    public static implicit operator Vec<T, T1>((T a0, T1 a1) a) => new(a.a0, a.a1);
    public static implicit operator Vec<T, T1>(Vec<T, T1>* a) => new(a->_, a->_1);
    public static explicit operator (T a0, T1 a1)(Vec<T, T1> a) => (a._, a._1);
}

public unsafe record struct Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T _, T1 _1, T2 _2, T3 _3, T4 _4, T5 _5, T6 _6, T7 _7, T8 _8, T9 _9)
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
    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>((T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9) a) => new(a.a0, a.a1, a.a2, a.a3, a.a4, a.a5, a.a6, a.a7, a.a8, a.a9);
    public static implicit operator Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>* a) => new(a->_, a->_1, a->_2, a->_3, a->_4, a->_5, a->_6, a->_7, a->_8, a->_9);
    public static explicit operator (T a0, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9)(Vec<T, T1, T2, T3, T4, T5, T6, T7, T8, T9> a) => (a._, a._1, a._2, a._3, a._4, a._5, a._6, a._7, a._8, a._9);
}