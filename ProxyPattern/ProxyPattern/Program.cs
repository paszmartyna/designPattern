using System;

namespace ProxyPattern
{
    class ProxyPattern :SpaceBookSystem
    {
        static void Main( )
        {
            MySpaceBook me = new MySpaceBook();
            me.Add("hello world");
            me.Add("Today I worked 18h");
            MySpaceBook tom = new MySpaceBook();
            tom.Poke("Judith");
            tom.Add("Judith", "poor you");
            tom.Add("Off to see...");
        }
    }
}
