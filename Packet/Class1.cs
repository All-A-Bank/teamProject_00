using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

public enum PacketType
{
    에러 = 0,
    회원가입,
    로그인,
    유저이름요청,
}

namespace PacketClass
{
    [Serializable]
    public class Packet
    {
        public int length;
        public int type;
        public string message;
        public string errorMessage;

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
        public string name;

        public SignUp()
        {
            this.userId = null;
            this.password = null;
            this.name = null;
        }
    }

    [Serializable]
    public class Login : Packet
    {
        public string userId;
        public string password;

        public Login()
        {
            this.userId = null;
            this.password = null;
        }
    }
}
