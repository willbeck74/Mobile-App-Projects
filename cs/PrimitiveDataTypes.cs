﻿using System;
using System.Collections.Generic;
using System.Text;

namespace cs {
    enum Color {
        Red, Green, Blue, Yellow, Cyan = 10, Magenta, White, Black
    };
    enum Orientation {
        Horizontal, Vertical
    };
    public class PrimitiveDataTypes {
        public static void DataTypesMain(String[] args) {
            byte b = 255;
            short s = 32767;
            int i = 2147483647;
            long l = 9223372036854775807;
            float f = 3.141f;
            double d = 3.141;
            decimal dec = 3.141M;
            String str = "hello";

            uint ui = 4294967295;
            var x = f;

            int[] ary = new int[10];
            for (i = 0; i < 10; i++)
                ary[i] = 2 * i;

            Console.WriteLine(str);
            System.Console.WriteLine(x.GetType());
            Console.WriteLine(x.GetType());             // Don't need the System prefix

            Orientation o = Orientation.Horizontal;
        }
    }
}
