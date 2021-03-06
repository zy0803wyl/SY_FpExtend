﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web
{
    public partial class PageConData : System.Web.UI.Page
    {
        string url = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/plain";
            url = GetFpUrl();
            if (string.IsNullOrEmpty(url))
            {
                Response.Redirect("Login.aspx");
            }
            string mark = Request.Params["conMarc"];
            switch (mark)
            {
                case "SexFlag": Response.Write(ReturnGender()); break;
                case "In_CodeType": Response.Write(ReturnIn_CodeType()); break;
                case "BloodTypeFlag": Response.Write(ReturnBloodTypeFlag()); break;
                case "SamplingMethod": Response.Write(ReturnSamplingMethodData()); break;
                case "DiagnoseTypeFlag": Response.Write(ReturnDiagnoseTypeFlag()); break;
                case "SampleTypes": Response.Write(ReturnSampleTypes()); break;
                default: Response.Write("");
                    break;
            }
        }

        private string GetFpUrl()
        {
            string username = Common.CookieHelper.GetCookieValue("username");
            string tempwd = Common.CookieHelper.GetCookieValue("password");
            if (string.IsNullOrEmpty(username)||string.IsNullOrEmpty(tempwd))
            {
                return "";
            }
            else
            {
                FreezerProUtility.Fp_BLL.FpUrlMaker FpUrlMaker = new FreezerProUtility.Fp_BLL.FpUrlMaker(username, Common.DEncrypt.DESEncrypt.Decrypt(tempwd));
                return FpUrlMaker.ConnFpUrl;
            }
        }
        //初始化唯一选择框
        private string ReturnIn_CodeType()
        {
            string res = "[{\"In_CodeType\": \"1\",\"text\": \"诊疗卡号码\" },{\"In_CodeType\": \"2\", \"text\": \"住院号\"}, { \"In_CodeType\": \"3\", \"text\": \"门诊流水号\"},{\"In_CodeType\": \"4\",\"text\": \"患者ID\" },{\"In_CodeType\": \"5\", \"text\": \"住院记录ID\"}, { \"In_CodeType\": \"6\", \"text\": \"检验标签条码\"} ]";
            return res;
        }
        //初始化性别
        private string ReturnGender()
        {
            string res = "[{\"SexFlag\": \"0\",\"text\": \"未知\" },{\"SexFlag\": \"1\", \"text\": \"男\"}, { \"SexFlag\": \"2\", \"text\": \"女\"} ]";
            return res;
        }
        //初始化血型
        private string ReturnBloodTypeFlag()
        {
            string res = "[{\"BloodTypeFlag\": \"1\",\"text\": \"A\" },{\"BloodTypeFlag\": \"2\", \"text\": \"B\"}, { \"BloodTypeFlag\": \"3\", \"text\": \"AB\"},{\"BloodTypeFlag\": \"4\",\"text\": \"O\" },{\"BloodTypeFlag\": \"5\", \"text\": \"其它\"}, { \"BloodTypeFlag\": \"6\", \"text\": \"未查\"} ]";
            return res;
        }
        private string ReturnSamplingMethodData()
        {
            string res = "[{ \"samplingMethod\": \"手术前\", \"text\": \"手术前\" }, { \"samplingMethod\": \"手术时\", \"text\": \"手术时\" },{ \"samplingMethod\": \"手术一周后\", \"text\": \"手术一周后\" }, { \"samplingMethod\": \"化疗前\", \"text\": \"化疗前\" },{ \"samplingMethod\": \"化疗两周期结束后，第三周化疗期前\", \"text\": \"化疗两周期结束后，第三周化疗期前\" },{ \"samplingMethod\": \"第五周期化疗前\", \"text\": \"第五周期化疗前\" },{ \"samplingMethod\": \"第六周期化疗技术后\", \"text\": \"第六周期化疗技术后\" },{ \"samplingMethod\": \"靶向治疗前\", \"text\": \"靶向治疗前\" },{ \"samplingMethod\": \"疾病出现进展时\", \"text\": \"疾病出现进展时\" },{ \"samplingMethod\": \"更换治疗方案前\", \"text\": \"更换治疗方案前\" },{ \"samplingMethod\": \"其他\", \"text\": \"其他\" } ]";
            return res;
        }
        private string ReturnDiagnoseTypeFlag()
        {
            string res = "[{\"DiagnoseTypeFlag\": \"0\",\"text\": \"门诊诊断\" },{\"DiagnoseTypeFlag\": \"1\", \"text\": \"入院诊断\"}, { \"DiagnoseTypeFlag\": \"2\", \"text\": \"出院主要诊断\"} , { \"DiagnoseTypeFlag\": \"3\", \"text\": \"出院次要诊\"} ]";
            return res;
        }
        private string ReturnSampleTypes()
        {
            Dictionary<string, string> sampleNameDic = FreezerProUtility.Fp_BLL.Samples.GetAllSample_TypesNames(url);
            
            string res = "[{\"value\": \"0\",\"text\": \"门诊诊断\" },{\"value\": \"1\", \"text\": \"入院诊断\"}, { \"value\": \"2\", \"text\": \"出院主要诊断\"} , { \"value\": \"3\", \"text\": \"出院次要诊\"} ]";
            return res;
        }

    }
}