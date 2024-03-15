using Application.Features.Brands.Models;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;

namespace Application.Features.Brands.Queries.GetListDynamic;

public class GetListBrandDynamicQuery:IRequest<BrandListModel>
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }
}
