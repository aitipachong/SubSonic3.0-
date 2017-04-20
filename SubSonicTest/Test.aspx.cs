using Solution.DataAccess.DataModel;
using SubSonic.Linq.Structure;
using SubSonic.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SubSonicTest
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //---------------------------------------------------------
            // 1、新增记录
            //---------------------------------------------------------
            var branch = new Branch();
            branch.DeptCode = SPs.P_Branch_GetMaxBranchDeptCode(2, 1).ExecuteScalar() + "";
            branch.Name = "客服部";
            branch.Comment = "客户售后服务维护部门";
            branch.ParentId = 1;
            branch.Sort = 7;
            branch.Depth = 2;
            //AddDate这个属性不用赋值，ORM框架生成更新语句时会自动过滤该字段，更新时将会使用数据库中设置的默认值
            //branch.AddDate = DateTime.Now;

            //保存数据入库 
            branch.Save();
            WriteLine("记录添加成功,新增Id为：" + branch.Id);


            //----------------------------------------------------------
            // 2、修改记录
            //----------------------------------------------------------
            var branchModel = Branch.SingleOrDefault(x => x.Id == branch.Id);
            //也可以这样用
            //var branchModel = new Branch(x => x.Id == branch.Id);
            //打印读取出来的数据
            WriteLine(branchModel.ToString());

            //修改名称为“售后服务部”
            branchModel.Name = "售后服务部";
            //保存
            branchModel.Save();

            //重新从数据库中读取出来并打印到输出窗口
            WriteLine((new Branch(x => x.Id == branch.Id)).ToString());


            //----------------------------------------------------------
            // 3、判断刚刚修改的记录是否存在
            //----------------------------------------------------------
            if(Branch.Exists(x => x.Id == branch.Id))
            {
                WriteLine("Id为" + branch.Id + "的记录存在！");
            }
            else
            {
                WriteLine("Id为" + branch.Id + "的记录不存在！");
            }


            //---------------------------------------------------------
            // 4、删除记录
            //---------------------------------------------------------
            //删除当前记录
            Branch.Delete(x => x.Id == branch.Id);
            //也可以这样操作：
            //branchModel.Delete();
            WriteLine("删除Id为" + branch.Id + "的记录成功！");


            //--------------------------------------------------------
            // 5、判断刚刚删除的记录是否存在
            //--------------------------------------------------------
            if(Branch.Exists(x => x.Id == branch.Id))
            {
                WriteLine("Id为" + branch.Id + "的记录存在！");
            }
            else
            {
                WriteLine("Id为" + branch.Id + "的记录不存在！");
            }


            //--------------------------------------------------------
            // 6、使用类实体附带的函数查询
            //--------------------------------------------------------
            //查找出所有记录 -- 使用All()
            var list = Branch.All();
            foreach(var item in list)
            {
                //打印记录到输出窗口
                WriteLine(item.ToString());
            }

            //查询指定条件的记录 -- 使用Find()
            IList<Branch> il = Branch.Find(x => x.Id > 2);
            foreach(var item in il)
            {
                WriteLine(item.ToString());
            }

            //获取第二页记录（每页3条记录）
            il = Branch.GetPaged("Id Asc", 2, 3);
            foreach(var item in il)
            {
                WriteLine(item.ToString());
            }

            //使用Id倒序排序，获取第三页记录（每页3条记录）
            il = Branch.GetPaged("Id Desc", 3, 3);
            foreach (var item in il)
            {
                WriteLine(item.ToString());
            }


            //--------------------------------------------------
            // 7、使用Select类查询
            //--------------------------------------------------
            //创建Select对象
            //var select = new Select();
            //显示指定的列
            var select = new Select(new string[] { BranchTable.Id, BranchTable.Name, BranchTable.DeptCode });
            //指定查询表
            select.From<Branch>();

            //运行完上面这条语句后，SQL已经生成出来了，在Debug状态将鼠标指向select就可以看到，往下继续执行时，每添加一个属性都会添加在生成的SQL语句中
            //添加查询条件 -- Id大于2且编号头两位为01的部门
            select.Where(BranchTable.Id).IsGreaterThanOrEqualTo(2).And(BranchTable.DeptCode).StartsWith("01");
            //查询时括号添加列子
            //select.OpenExpression().Where("").IsEqualTo(0).Or("").IsEqualTo(11).CloseExpression().And("").IsEqualTo(3);

            //设置去重复 -- SubSonic没有去重复选项，需要自己手动修改DLL源码
            select.Distinct(true);
            //或
            //select.IsDistinct = true;

            //设置查询数量
            select.Top("5");

            //添加排序 -- 倒序
            select.OrderDesc(BranchTable.Sort);
            //或 
            //List<string> orderByList = new List<string>();
            //orderByList.Add(BranchTable.Sort + " Desc");
            //orderByList.Add(BranchTable.Id + " Desc");
            //select.OrderBys = orderByList;

            //设置分页，获取第一页记录(每页10条记录）
            select.Paged(1, 10);

            //执行查询 -- 返回DataTable
            var dt = select.ExecuteDataTable();
            if(dt != null && dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    WriteLine(dt.Rows[i][BranchTable.Id] + " " + dt.Rows[i][BranchTable.Name]);
                }
            }

            //执行查询 -- 返回List
            var bl = select.ToList<Branch>();
            foreach(var item in bl)
            {
                WriteLine(item.ToString());
            }

            //查询总记录数
            var recordCount = select.GetRecordCount();
            WriteLine("记录数量：" + recordCount.ToString());


            //-------------------------------------------------------------
            // 8、HotelDBDB查询类的使用方式
            //-------------------------------------------------------------
            //使用数据库名称+DB作为名称的类，可以直接调用聚合函数
            var db = new SubSonicTestDB();
            //平均值
            WriteLine("平均值：" + db.Avg<Branch>(x => x.Id).Where<Branch>(x => x.Id < 10).ExecuteScalar() + "");
            //计算数量
            WriteLine("计算数量：" + db.Count<Branch>(x => x.Id).ExecuteScalar() + "");
            //计算合计数量
            WriteLine("计算合计数量：" + db.Sum<Branch>(x => x.Id).ExecuteScalar() + "");
            //最大值
            WriteLine("最大值：" + db.Max<Branch>(x => x.Id).ExecuteScalar() + "");
            //最小值
            WriteLine("最小值：" + db.Min<Branch>(x => x.Id).ExecuteScalar() + "");


            //---------------------------------------------------------------
            // 9、存储过程调用方法
            //---------------------------------------------------------------
            //使用SPs.存储过程名称(参数1，参数2，参数3）就可以调用存储过程
            var obj = SPs.P_Branch_GetMaxBranchDeptCode(1, 0).ExecuteScalar();
            WriteLine(obj + "");


            //---------------------------------------------------------------
            // 10、直接执行QueryCommand的方式
            //---------------------------------------------------------------
            //获取数据源 -- 主要用于绑定连接的服务器，如果有多台服务器多个数据库时，可使用不同的数据源来进行绑定查找
            var provider = SubSonic.DataProviders.ProviderFactory.GetProvider();
            //定义事务，给后面的事务调用
            var batch = new BatchQuery(provider);

            var sql = string.Format("select * from {0}", BranchTable.TableName);
            //例一：获取影响记录数
            QueryCommand qcCommand = new QueryCommand(sql, provider);
            WriteLine(qcCommand.Provider.ExecuteQuery(qcCommand) + "");

            //例二：获取DataTable
            var q = new SubSonic.Query.QueryCommand(sql, provider);
            var table = q.Provider.ExecuteDataSet(q).Tables[0];
            if(dt != null && table.Rows.Count > 0)
            {
                for(int i = 0; i < table.Rows.Count; i++)
                {
                    WriteLine(table.Rows[i][BranchTable.Id] + " " + table.Rows[i][BranchTable.Name]);
                }
            }

            //例三：使用事务执行
            batch.QueueForTransaction(qcCommand);
            batch.ExecuteTransaction();

            //例四：直接使用数据源执行
            provider.ExecuteQuery(qcCommand);


            //----------------------------------------------------------------
            // 11、Linq查询
            //----------------------------------------------------------------
            //Linq查询方式
            var query = new Query<Branch>(db.provider);
            var posts = from p in query
                        where p.DeptCode.StartsWith("0101")
                        select p;
            foreach(var item in posts)
            {
                WriteLine(item.ToString());
            }

            query = db.GetQuery<Branch>();
            posts = from p in query
                    where p.Id > 3 && p.Id < 6
                    select p;
            foreach(var item in posts)
            {
                WriteLine(item.ToString());
            }

            //获取查询结果2
            List<Branch> li2 = query.ToList<Branch>();
            foreach(var item in li2)
            {
                WriteLine(item.ToString());
            }


            //---------------------------------------------------------------------
            // 12、Linq多表关联查询
            //---------------------------------------------------------------------
            //方法一
            var query5 = from p in Position.All()
                         join b in Branch.All() on p.Branch_Id equals b.Id
                         where b.DeptCode == "0101"
                         select p;
            foreach(var item in query5)
            {
                WriteLine(item.ToString());
            }

            //方法二
            var qry = (from p in db.Position
                       join b in db.Branch on p.Branch_Id equals b.Id
                       where b.DeptCode == "0101"
                       select new ListView
                       {
                           PositionName = p.Name,
                           BranchName = p.Branch_Name,
                           DeptCode = b.DeptCode
                       });
            foreach(var item in qry)
            {
                WriteLine(item.ToString());
            }


            //-------------------------------------------------------------------------
            // 13、使用事务
            //-------------------------------------------------------------------------
            //例一
            //从部门表中查询出编号为0102的Id、名称与说明三列
            var query1 = new SubSonic.Query.Select(provider, BranchTable.Id, BranchTable.Name, BranchTable.Comment).From(
                BranchTable.TableName).Where<Branch>(x => x.DeptCode == "0102");
            //加入事务
            batch.QueueForTransaction(query1);

            //查询部门编号为0102且职位名称后面两个字为主管的所有职位
            var query2 = new SubSonic.Query.Select(provider).From<Position>().Where<Position>(x => x.Branch_DeptCode == "0102").And(
                PositionTable.Name).EndsWith("主管");
            //加入事务
            batch.QueueForTransaction(query2);
            //运行事务,不返回任何信息
            batch.ExecuteTransaction();

            //例二
            batch = new BatchQuery();
            batch.Queue(query1);
            batch.Queue(query2);
            //执行事务，并返回数据
            using (IDataReader rdr = batch.ExecuteReader())
            {
                if(rdr.Read())
                {
                    //query1 results
                    for(int i = 0; i < rdr.FieldCount; i++)
                    {
                        WriteLine(rdr[i] + "");
                    }
                }
                rdr.NextResult();
                if(rdr.Read())
                {
                    //query2 results
                    for(int i = 0; i < rdr.FieldCount; i++)
                    {
                        WriteLine(rdr[i] + "");
                    }
                }
            }

            //例三
            batch = new BatchQuery(provider);
            var query3 = from p in db.Branch
                         where p.Id > 1 && p.Id < 10
                         select p;
            batch.Queue(query3);

            var query4 = from p in db.Position
                         where p.Branch_DeptCode == "0103"
                         select p;
            batch.Queue(query4);

            //执行事务，并返回数据
            using (var rdr = batch.ExecuteReader())
            {
                if(rdr.Read())
                {
                    //query3 results
                    for(int i = 0; i < rdr.FieldCount; i++)
                    {
                        WriteLine(rdr[i] + "");
                    }
                }
                rdr.NextResult();
                if (rdr.Read())
                {
                    //query4 results
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        WriteLine(rdr[i] + "");
                    }
                }

            }
        }

        /// <summary>
        /// Debug模式下，在输出窗口打印指定内容
        /// </summary>
        /// <param name="str"></param>
        private void WriteLine(string str)
        {
            System.Diagnostics.Debug.WriteLine(str);
        }

        class ListView
        {
            public string PositionName { get; set; }
            public string BranchName { get; set; }
            public string DeptCode { get; set; }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("PositionName = " + PositionName + "\r\n");
                sb.Append("BranchName = " + BranchName + "\r\n");
                sb.Append("DeptCode = " + DeptCode + "\r\n");
                return sb.ToString();
            }
        }
    }
}