 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// Position表实体类
    /// </summary>
    public partial class Position
    {

		int _Id = 0;
		/// <summary>
		/// 主键Id
		/// </summary>
		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		string _Name = "";
		/// <summary>
		/// 职位名称
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		int _Branch_Id = 0;
		/// <summary>
		/// 部门自编号ID
		/// </summary>
		public int Branch_Id
		{
			get { return _Branch_Id; }
			set { _Branch_Id = value; }
		}

		string _Branch_DeptCode = "";
		/// <summary>
		/// 部门编号
		/// </summary>
		public string Branch_DeptCode
		{
			get { return _Branch_DeptCode; }
			set { _Branch_DeptCode = value; }
		}

		string _Branch_Name = "";
		/// <summary>
		/// 部门名称
		/// </summary>
		public string Branch_Name
		{
			get { return _Branch_Name; }
			set { _Branch_Name = value; }
		}

		string _PagePower = "";
		/// <summary>
		/// 菜单操作权限，有操作权限的菜单ID列表：|1|2|3|4|5|
		/// </summary>
		public string PagePower
		{
			get { return _PagePower; }
			set { _PagePower = value; }
		}

		string _ControlPower = "";
		/// <summary>
		/// 页面功能操作权限，各个页面有操作权限的菜单ID和页面权限标志ID列表：|1,1|2,1|2,2|2,4|
		/// </summary>
		public string ControlPower
		{
			get { return _ControlPower; }
			set { _ControlPower = value; }
		}

		byte _IsFinance = 0;
		/// <summary>
		/// 是否财务人员，0=否，1=是
		/// </summary>
		public byte IsFinance
		{
			get { return _IsFinance; }
			set { _IsFinance = value; }
		}

		byte _IsSetBranchPower = 0;
		/// <summary>
		/// 是否有绑定指定部门操作权限，0=无，1=有 （对SetDeptCode操作限制，一般对于小型公司没有作用，对于全国性有多分公司企业，且各企业的人事或财务是各自独立的才有大作用）
		/// </summary>
		public byte IsSetBranchPower
		{
			get { return _IsSetBranchPower; }
			set { _IsSetBranchPower = value; }
		}

		string _SetDeptCode = "";
		/// <summary>
		/// 绑定有权限操作的部门，绑定后该职位进入部门或职位编辑时，只能编辑该部门里的相关信息
		/// </summary>
		public string SetDeptCode
		{
			get { return _SetDeptCode; }
			set { _SetDeptCode = value; }
		}

		DateTime _AddDate = new DateTime(1900,1,1);
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime AddDate
		{
			get { return _AddDate; }
			set { _AddDate = value; }
		}
    } 

}


