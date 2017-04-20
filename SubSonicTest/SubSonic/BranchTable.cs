 
using System;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: Branch
        /// Primary Key: Id
        /// </summary>

        public class BranchTable {
			/// <summary>
			/// 表名
			/// </summary>
			public static string TableName {
				get{
        			return "Branch";
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
			/// 部门ID，内容为010101，即每低一级部门，编码增加两位小数
			/// </summary>
   			public static string DeptCode{
			      get{
        			return "DeptCode";
      			}
		    }
			/// <summary>
			/// 部门名称
			/// </summary>
   			public static string Name{
			      get{
        			return "Name";
      			}
		    }
			/// <summary>
			/// 说明
			/// </summary>
   			public static string Comment{
			      get{
        			return "Comment";
      			}
		    }
			/// <summary>
			/// 父ID
			/// </summary>
   			public static string ParentId{
			      get{
        			return "ParentId";
      			}
		    }
			/// <summary>
			/// 排序
			/// </summary>
   			public static string Sort{
			      get{
        			return "Sort";
      			}
		    }
			/// <summary>
			/// 深度
			/// </summary>
   			public static string Depth{
			      get{
        			return "Depth";
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
