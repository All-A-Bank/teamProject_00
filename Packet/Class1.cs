using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

public enum PacketType
{
    회원가입 = 0,
    로그인
}

public enum PacketSendERROR
{
    정상 = 0,
    에러
}

namespace PacketClass
{
    [Serializable]
    public class Packet
    {
        public int length;
        public int type;

        public Packet()
        {
            this.length = 0;
            this.type = 0;
        }

        public static byte[] Serialize(Object o)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }

        public static Object Desserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            foreach (byte b in bt)
            {
                ms.WriteByte(b);
            }

            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }

    [Serializable]
    public class SignUp : Packet
    {
        public string userId;
        public string password;

        public SignUp()
        {
            userId = null;
            password = null;
        }
    }

    [Serializable]
    public class Login : Packet
    {
        public string userId;

        public Login()
        {
            this.userId = null;
        }
    }
}
