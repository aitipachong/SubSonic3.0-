 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: Position
        /// Primary Key: Id
        /// </summary>

        public class PositionStructs: DatabaseTable {
            
            public PositionStructs(IDataProvider provider):base("Position",provider){
                ClassName = "Position";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Id"
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "Name"
                });

                Columns.Add(new DatabaseColumn("Branch_Id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Branch_Id"
                });

                Columns.Add(new DatabaseColumn("Branch_DeptCode", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "Branch_DeptCode"
                });

                Columns.Add(new DatabaseColumn("Branch_Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 25,
					PropertyName = "Branch_Name"
                });

                Columns.Add(new DatabaseColumn("PagePower", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1073741823,
					PropertyName = "PagePower"
                });

                Columns.Add(new DatabaseColumn("ControlPower", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1073741823,
					PropertyName = "ControlPower"
                });

                Columns.Add(new DatabaseColumn("IsFinance", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "IsFinance"
                });

                Columns.Add(new DatabaseColumn("IsSetBranchPower", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "IsSetBranchPower"
                });

                Columns.Add(new DatabaseColumn("SetDeptCode", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "SetDeptCode"
                });

                Columns.Add(new DatabaseColumn("AddDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "AddDate"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }


        public new IColumn Name
        {
            get
            {
                return this.GetColumn("Name");
            }
        }


        public IColumn Branch_Id{
                get{
                    return this.GetColumn("Branch_Id");
                }
            }
				
            
            public IColumn Branch_DeptCode{
                get{
                    return this.GetColumn("Branch_DeptCode");
                }
            }
				
            
            public IColumn Branch_Name{
                get{
                    return this.GetColumn("Branch_Name");
                }
            }
				
            
            public IColumn PagePower{
                get{
                    return this.GetColumn("PagePower");
                }
            }
				
            
            public IColumn ControlPower{
                get{
                    return this.GetColumn("ControlPower");
                }
            }
				
            
            public IColumn IsFinance{
                get{
                    return this.GetColumn("IsFinance");
                }
            }
				
            
            public IColumn IsSetBranchPower{
                get{
                    return this.GetColumn("IsSetBranchPower");
                }
            }
				
            
            public IColumn SetDeptCode{
                get{
                    return this.GetColumn("SetDeptCode");
                }
            }
				
            
            public IColumn AddDate{
                get{
                    return this.GetColumn("AddDate");
                }
            }
				
            
                    
        }
        
}
