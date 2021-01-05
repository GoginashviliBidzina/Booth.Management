using System;
using System.Linq;

namespace Booth.Application.Helpers
{
    public static class StringHelpers
    {
        public static int[] ToNewArray(this string text)
        => text?.Split(';')
                .Select(boothId => Convert.ToInt32(boothId))
                .ToArray();

        public static string ToNewString(this int[] array)
        => array?.Any() == true ? string.Join(',', array) :
                                  string.Empty;

    }
}
