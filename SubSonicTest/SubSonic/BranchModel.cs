 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// Branch表实体类
    /// </summary>
    public partial class Branch
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

		string _DeptCode = "";
		/// <summary>
		/// 部门ID，内容为010101，即每低一级部门，编码增加两位小数
		/// </summary>
		public string DeptCode
		{
			get { return _DeptCode; }
			set { _DeptCode = value; }
		}

		string _Name = "";
		/// <summary>
		/// 部门名称
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		string _Comment = "";
		/// <summary>
		/// 说明
		/// </summary>
		public string Comment
		{
			get { return _Comment; }
			set { _Comment = value; }
		}

		int _ParentId = 0;
		/// <summary>
		/// 父ID
		/// </summary>
		public int ParentId
		{
			get { return _ParentId; }
			set { _ParentId = value; }
		}

		int _Sort = 0;
		/// <summary>
		/// 排序
		/// </summary>
		public int Sort
		{
			get { return _Sort; }
			set { _Sort = value; }
		}

		int _Depth = 0;
		/// <summary>
		/// 深度
		/// </summary>
		public int Depth
		{
			get { return _Depth; }
			set { _Depth = value; }
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


