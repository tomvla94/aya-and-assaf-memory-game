using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            plumbingMenuUsingInterfaces iterfaceMenu = new plumbingMenuUsingInterfaces();
            iterfaceMenu.Run();

            plumbingMenuUsingDelegates delegateMenu = new plumbingMenuUsingDelegates();
            delegateMenu.Run();
        }
    }
}
