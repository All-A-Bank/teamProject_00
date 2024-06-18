using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

public enum PacketType
{
    에러 = 0,
    회원가입,
    로그인,
    유저이름과예산요청,
    수입추가,
    지출추가,
    예산추가,
    수입목록요청,
    지출목록요청,
    재정데이터요청,
    카테고리이름요청,
    수입월목록요청,  // 추가된 부분
    지출월목록요청   // 추가된 부분

}

namespace PacketClass
{
    [Serializable]
    public class Packet
    {
        public int length;
        public int type;
        public List<string> message;
        public string errorMessage;

        public Packet()
        {
            this.length = 0;
            this.type = 0;
            this.message  = new List<string>();
            errorMessage = "";
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

    [Serializable]
    public class IncomeAdd : Packet
    {
        public int category_id;
        public string userId;
        public decimal amount;
        public string description;
        public DateTime date;

        public IncomeAdd()
        {
            this.category_id = 0;
            this.userId = null;
            this.amount = 0;
            this.description = null;
            this.date = DateTime.MinValue;
        }
    }

    [Serializable]
    public class ExpenseAdd : Packet
    {
        public int category_id;
        public string userId;
        public decimal amount;
        public string description;
        public DateTime date;

        public ExpenseAdd()
        {
            this.category_id = 0;
            this.userId = null;
            this.amount = 0;
            this.description = null;
            this.date = DateTime.MinValue;
        }
    }

    [Serializable]
    public class Budget : Packet
    {
        public decimal amount;
        public string userId;

        public Budget()
        {
            this.amount = 0;
            userId = null;
        }
    }
}
