using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public Boolean CheckLogin(string email, string password) => MemberDAO.Instance.CheckLogin(email, password);

        public Member GetMemberByEmail(string email) => MemberDAO.Instance.GetMemberByEmail(email);

        public Member GetMemberByID(int? id) => MemberDAO.Instance.GetMemberByID((int)id);    

        public List<Member> GetMemberList() => MemberDAO.Instance.GetMemberList();

        public Boolean UpdateMember(Member member) => MemberDAO.Instance.UpdateMember(member);
        public Boolean DeleteMember(Member member) => MemberDAO.Instance.DeleteMember(member);
        public Boolean AddMember(Member member) => MemberDAO.Instance.AddMember(member);

    }
}
