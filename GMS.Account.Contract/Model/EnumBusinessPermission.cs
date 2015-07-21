using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMS.Framework.Utility;

namespace GMS.Account.Contract
{
    public enum EnumBusinessPermission
    {
        [EnumTitle("[无]", IsDisplay = false)]
        None = 0,
        /// <summary>
        /// 管理用户
        /// </summary>
        [EnumTitle("管理用户")]
        AccountManage_User = 101,

        /// <summary>
        /// 管理角色
        /// </summary>
        [EnumTitle("管理角色")]
        AccountManage_Role = 102,



        [EnumTitle("CMS管理文章")]
        CmsManage_Article = 201,

        [EnumTitle("CMS管理文章频道")]
        CmsManage_Channel = 202,


        [EnumTitle("CRM管理来访来电")]
        CrmManage_VisitRecord = 301,

        [EnumTitle("CRM客户管理")]
        CrmManage_Customer = 302,

        [EnumTitle("CRM项目管理")]
        CrmManage_Project = 303,

        [EnumTitle("CRM查看统计信息")]
        CrmManage_Analysis = 304,


        [EnumTitle("OA管理员工")]
        OAManage_Staff = 401,

        [EnumTitle("OA管理部门")]
        OAManage_Branch = 402,

        [EnumTitle("组织结构管理")]
        OAManage_Org = 403,

        
        [EnumTitle("管理分类")]
        Basis_Classification = 501,

        [EnumTitle("管理材料")]
        Basis_Material = 502,

        [EnumTitle("管理供应商")]
        Basis_Supplier= 503,



        [EnumTitle("项目管理")]
        ProjectManage_Basedata = 601,

        [EnumTitle("项目预算管理")]
        ProjectManage_Budget = 602,

        [EnumTitle("即时预算管理")]
        ProjectManage_InsBudget = 603,

        //-------------------------------------------预算---------------------------------------------------------
        [EnumTitle("项目人工预算")]
        ProjectManage_Labor = 701,

        [EnumTitle("项目机械费用预算")]
        ProjectManage_Machine = 702,

        [EnumTitle("项目材料费用预算")]
        ProjectManage_Material = 703,

        [EnumTitle("项目措施费用预算")]
        ProjectManage_Measure = 704,

        [EnumTitle("项目间接费用预算")]
        ProjectManage_Overhead = 705,
        //--------------------------------------------财务管理--------------------------------------------------------------
        [EnumTitle("应付款管理")]
        ProjectManage_Payables = 801,
        [EnumTitle("应收款管理")]
        ProjectManage_Income = 803,

        [EnumTitle("会计科目管理")]
        ProjectManage_Accounting = 802,

        //-----------------------------------------------即时管理------------------------------------------

        [EnumTitle("即时人工")]
        ProjectManage_InsLabor = 901,

        [EnumTitle("即时机械费用")]
        ProjectManage_InsMachine = 902,

        [EnumTitle("即时材料费用")]
        ProjectManage_InsMaterial = 903,

        [EnumTitle("即时措施费用")]
        ProjectManage_InsMeasure = 904,

        [EnumTitle("即时间接费用")]
        ProjectManage_InsOverhead = 905,

        //===---------------------------资产管理----------------------------
        [EnumTitle("文档管理")]
        ProjectManage_File = 1001,

        [EnumTitle("余料管理")]
        ProjectManage_Oddments = 1002,

        [EnumTitle("项目采购管理")]
        ProjectManage_OfficeCtrl = 1003,

        [EnumTitle("公司采购管理")]
        ProjectManage_ProjectCtrl = 1004,

    }
}
