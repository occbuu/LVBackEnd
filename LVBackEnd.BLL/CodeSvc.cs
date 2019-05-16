using Newtonsoft.Json;
using SKG.BLL;
using SKG.Ext;
using SKG.Req;
using SKG.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LVBackEnd.BLL
{
    using DAL;
    using DAL.Models;
    using Filter;

    /// <summary>
    /// Code service
    /// </summary>
    public class CodeSvc : GenericSvc<CodeRep, Code>
    {
        #region -- Overrides --

        /// <summary>
        /// Create the Code
        /// </summary>
        /// <param name="m">The Code</param>
        /// <returns>Return the result</returns>
        //public override SingleRsp Create(Code m)
        //{
        //    return base.Create(m);
        //}

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="code">Secondary key</param>
        /// <returns>Return the object</returns>
        //public override SingleRsp Read(string code)
        //{
        //    var res = new SingleRsp();

        //    try
        //    {
        //        var t = code.Split(ZConst.Char.VBar);
        //        var day = t[0];
        //        var month = t[1];
        //        var year = t[2];

        //        res.Data = _rep.Read(day, month, year);
        //    }
        //    catch { }

        //    return res;
        //}

        /// <summary>
        /// Read By KeyWord with paging
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public override SearchRsp Read(PagingReq req)
        {
            var res = new SearchRsp(req);

            try
            {
                // Get data
                var filter = new CodeFilter();
                if (req.Filter != null)
                {
                    filter = JsonConvert.DeserializeObject<CodeFilter>(req.Filter.ToString());
                }
                var page = req.Page;
                var size = req.Size;
                var offset = (page - 1) * size;
                var query = All;

                #region -- Filter --

                if (!string.IsNullOrEmpty(filter.CodeType))
                {
                    query = query.Where(p => p.CodeType.Contains(filter.CodeType));
                }

                #endregion

                res.TotalRecords = query.Count();

                if (req.Paging)
                {
                    query = query.OrderByDescending(p => p.Id)
                        .Sort(req.Sort)
                        .Skip(offset)
                        .Take(size);
                }

                var t = query.ToList()
                    .Select(p => new
                    {
                        p.Id,
                        p.DisplayAs,
                        p.CodeType,
                        p.Status
                    });

                res.Data = t;
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }

            return res;
        }

        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public CodeSvc()
        {
            _repType = new CodeTypeRep();
        }

        /// <summary>
        /// Get all holidays of the year
        /// </summary>
        /// <param name="codeType">Year</param>
        /// <returns>Return the result</returns>
        public MultipleRsp ReadByCodeType(List<string> codeType)
        {
            MultipleRsp res = new MultipleRsp();
            foreach (string i in codeType)
            {
                var o = All.Where(p => p.CodeType.Contains(i)).ToList();
                res.SetData(i, o);
            };

            return res;
        }

        /// <summary>
        /// Get code type
        /// </summary>
        /// <returns>Return the result</returns>
        public SingleRsp ReadType()
        {
            var res = new SingleRsp();

            var t = (from a in _repType.Context.CodeType
                     select new
                     {
                         a.Code,
                         a.DisplayAs
                     }).ToList();

            res.Data = t;

            return res;
        }


        #endregion


        #region -- Fields --

        /// <summary>
        /// Code type rep
        /// </summary>
        CodeTypeRep _repType;

        #endregion
    }
}