using DairElAnbaBeshoy.AppLogic.Manager;
using DairElAnbaBeshoy.Core.Defaults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;

namespace DairElAnbaBeshoy.Controller
{

    [Route( "api/AllRetriversList" )]
    [ApiController]
    [Authorize( Roles = nameof( Roles.Admin ) )]
    public class AllRetriversListController : ControllerBase
    {

        private readonly RetreaveManager registerRetreaveManager;

        public AllRetriversListController( RetreaveManager registerRetreaveManager )
        {

            this.registerRetreaveManager = registerRetreaveManager;
        }
        [HttpPost]

        public IActionResult Index( )
        {
            var pageSize = int.Parse( Request.Form[ "length" ] );
            var skip = int.Parse( Request.Form[ "start" ] );


            var sortColumn = Request.Form[ string.Concat( "columns[" , Request.Form[ "order[0][column]" ] , "][name]" ) ];
            var sortColumnDirection = Request.Form[ "order[0][dir]" ];
            var searchValue = Request.Form[ "search[value]" ];
            var Retrieves = registerRetreaveManager.GetAllRetrives( searchValue ).AsQueryable( );

            if ( !(string.IsNullOrEmpty( sortColumn ) && string.IsNullOrEmpty( sortColumnDirection )) )
                Retrieves = Retrieves.OrderBy( string.Concat( sortColumn , " " , sortColumnDirection ) );

            var data = Retrieves.Skip( skip ).Take( pageSize ).ToList( );

            var recordsTotal = Retrieves.Count( );

            var jsonData = new { recordsFiltered = recordsTotal , recordsTotal , data };

            return Ok( jsonData );

        }
    }
}
