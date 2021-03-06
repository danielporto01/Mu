﻿using Mu.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mu.Models
{
    public class Register
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Nome { get; set; }
        public string SecretQuestion { get; set; }
        public string SecretResp { get; set; }
        public string Email { get; set; }

        public void Save()
        {
            

            var section = Mu.MvcApplication.SessionFactory.GetCurrentSession();

            var user = section.QueryOver<MembInfo>().Where(i => i.MembId == Id).SingleOrDefault();
            if (user != null)
            {
                throw new Exception("Usuario já Cadastrado");
            }
            var validation = new Models.Validations.Inputs();
            validation.UserID(Id);
            validation.PasswordString(Password, PasswordConfirm);
            validation.EmailString(Email);

            var regscript = " INSERT INTO MEMB_INFO ("
                + "memb_guid,"
                + "memb___id,"
                + "memb__pwd,"
                + "memb_name,"
                + "sno__numb,"
                + "post_code,"
                + "addr_info,"
                + "addr_deta,"
                + "tel__numb,"
                + "mail_addr,"
                + "phon_numb,"
                + "fpas_ques,"
                + "fpas_answ,"
                + "job__code,"
                + "appl_days,"
                + "modi_days,"
                + "out__days,"
                + "true_days,"
                + "mail_chek,"
                + "bloc_code,"
                + "ctl1_code) "
                + "VALUES ("
                + "'1',"
                + "'" + Id + "',"
                + "'" + Password + "',"
                + "'" + Id + "',"
                + "'0000000',"
                + "'1234',"
                + "'11111',"
                + "'1234',"
                + "'12343',"
                + "'" + Email + "',"
                + "'" + SecretQuestion + "',"
                + "'" + SecretResp + "',"
                + "'0',"
                + "'1',"
                + "'2003-11-23',"
                + "'2003-11-23',"
                + "'2003-11-23',"
                + "'2003-11-23',"
                + "'1',"
                + "'0',"
                + "'1')"

                + "INSERT INTO VI_CURR_INFO ("
                + "ends_days,"
                + "chek_code,"
                + "used_time,"
                + "memb___id,"
                + "memb_name,"
                + "memb_guid,"
                + "sno__numb,"
                + "Bill_Section,"
                + "Bill_value,"
                + "Bill_Hour,"
                + "Surplus_Point,"
                + "Surplus_Minute,"
                + "Increase_Days)"
                + "VALUES ("
                + "'2005',"
                + "'1',"
                + "1234,"
                + "'" + Id + "',"
                + "'" + Id + "',"
                + "1,"
                + "'7',"
                + "'6',"
                + "'3',"
                + "'6',"
                + "'6',"
                + "'2003-11-23 10:36:00',"
                + "'0'"
                + ")";

            var query = section.CreateSQLQuery(regscript);
            query.ExecuteUpdate();



        }
    }
}