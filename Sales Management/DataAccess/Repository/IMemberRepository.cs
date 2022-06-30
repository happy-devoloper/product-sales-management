using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        Boolean CheckLogin(string email, string password);
        Member GetMemberByEmail(string email);
        Boolean UpdateMember(Member member);
        List<Member> GetMemberList();
        Boolean DeleteMember(Member member);
        Boolean AddMember(Member member);
        Member GetMemberByID(int? memberId);
    }
}
