 
using System;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: Position
        /// Primary Key: Id
        /// </summary>

        public class PositionTable {
			/// <summary>
			/// 表名
			/// </summary>
			public static string TableName {
				get{
        			return "Position";
      			}
			}

			/// <summary>
			/// 主键Id
			/// </summary>
   			public static string Id{
			      get{
        			return "Id";
      			}
		    }
			/// <summary>
			/// 职位名称
			/// </summary>
   			public static string Name{
			      get{
        			return "Name";
      			}
		    }
			/// <summary>
			/// 部门自编号ID
			/// </summary>
   			public static string Branch_Id{
			      get{
        			return "Branch_Id";
      			}
		    }
			/// <summary>
			/// 部门编号
			/// </summary>
   			public static string Branch_DeptCode{
			      get{
        			return "Branch_DeptCode";
      			}
		    }
			/// <summary>
			/// 部门名称
			/// </summary>
   			public static string Branch_Name{
			      get{
        			return "Branch_Name";
      			}
		    }
			/// <summary>
			/// 菜单操作权限，有操作权限的菜单ID列表：|1|2|3|4|5|
			/// </summary>
   			public static string PagePower{
			      get{
        			return "PagePower";
      			}
		    }
			/// <summary>
			/// 页面功能操作权限，各个页面有操作权限的菜单ID和页面权限标志ID列表：|1,1|2,1|2,2|2,4|
			/// </summary>
   			public static string ControlPower{
			      get{
        			return "ControlPower";
      			}
		    }
			/// <summary>
			/// 是否财务人员，0=否，1=是
			/// </summary>
   			public static string IsFinance{
			      get{
        			return "IsFinance";
      			}
		    }
			/// <summary>
			/// 是否有绑定指定部门操作权限，0=无，1=有 （对SetDeptCode操作限制，一般对于小型公司没有作用，对于全国性有多分公司企业，且各企业的人事或财务是各自独立的才有大作用）
			/// </summary>
   			public static string IsSetBranchPower{
			      get{
        			return "IsSetBranchPower";
      			}
		    }
			/// <summary>
			/// 绑定有权限操作的部门，绑定后该职位进入部门或职位编辑时，只能编辑该部门里的相关信息
			/// </summary>
   			public static string SetDeptCode{
			      get{
        			return "SetDeptCode";
      			}
		    }
			/// <summary>
			/// 创建时间
			/// </summary>
   			public static string AddDate{
			      get{
        			return "AddDate";
      			}
		    }
                    
        }
}
