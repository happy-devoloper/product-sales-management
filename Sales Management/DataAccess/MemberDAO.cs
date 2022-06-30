using BussinessObject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public Boolean CheckLogin(string email, string password)
        {
            string fileName = "account.json";
            string json = File.ReadAllText(fileName);  // đọc text từ tập tin JSON

            // deserialize từ chuỗi đọc ở tập tin JSOn --> đối tượng DefaultAccount
            var adminAccount = JsonSerializer.Deserialize<Member>(json, null);

            Member member = GetMemberList().SingleOrDefault(mem => (mem.Email == email && mem.Password == password));
            if (member != null)
            {
                return false;
            }
            else
            if (email.Equals(adminAccount.Email) && password.Equals(adminAccount.Password))
            {
                return true;
            }
            else
            {
                throw new Exception("incorrect email or password");
            }
        }

        public List<Member> GetMemberList()
        {
            var members = new List<Member>();
            try
            {
                using var db = new FStoreDBContext();
                members = db.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }

        public Member GetMemberByEmail(string email)
        {
            using var db = new FStoreDBContext();
            Member member = db.Members.SingleOrDefault(mem => mem.Email == email);
            return member;
        }

        public Member GetMemberByID(int id)
        {
            Member member = null;
            try
            {
                using var db = new FStoreDBContext();
                member = db.Members.SingleOrDefault(mem => mem.MemberId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public Boolean AddMember(Member member)
        {
            using var db = new FStoreDBContext();
            Member mem = GetMemberByEmail(member.Email);
            Member memID = GetMemberByID(member.MemberId);
            try
            {
                if (mem != null)
                {
                    throw new Exception("This Email has already exist!!");
                }
                else if(mem != null)
                {
                    throw new Exception("This Member ID has already exist!!");
                }
                else if(member.Email == "" || member.Password == "" || member.CompanyName == "")
                {
                    throw new Exception("Fields can NOT be EMPTY!!");
                }
                else
                {
                    db.Members.Add(member);
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean UpdateMember(Member member)
        {
            using var db = new FStoreDBContext();

            try
            {
                 if (member.Email == "" || member.Password == "" || member.CompanyName == "")
                {
                    throw new Exception("Fields can NOT be EMPTY!!");
                }
                else
                {
                    db.Members.Update(member);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }

        public Boolean DeleteMember(Member member)
        {
            using var db = new FStoreDBContext();
            Member oldMember = GetMemberByID(member.MemberId);
            if (oldMember != null)
            {
                db.Members.Remove(member);
                db.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
