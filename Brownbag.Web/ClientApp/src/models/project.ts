//     This code was generated by a Reinforced.Typings tool. 
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.

module Models {
	export interface BlogPostsViewModel extends Models.PostViewModel
	{
		CreatedByUser: Models.UsersViewModel;
		UpdatedByUser: Models.UsersViewModel;
		CreatedDate: any;
		UpdatedDate: any;
	}
	export interface BlogFKViewModel extends Models.BlogViewModel
	{
		WeatherID: number;
		WeatherCityName: string;
	}
	export interface BlogViewModel
	{
		Id: number;
		Url: string;
		Rating: number;
		Posts: Models.PostViewModel[];
	}
	export interface GuidLookupViewModel
	{
		ID: any;
		Value: string;
	}
	export interface LookupViewModel
	{
		ID: number;
		Value: string;
	}
	export interface OptionsLookupViewModel
	{
		label: string;
		value: number;
		disabled: boolean;
	}
	export interface StringOptionsLookupViewModel
	{
		label: string;
		value: string;
		disabled: boolean;
	}
	export interface PostViewModel
	{
		Id: number;
		Title: string;
		Content: string;
		BlogId: number;
		Blog: any;
	}
	export interface UsersViewModel
	{
		Id: string;
		UserName: string;
		UserFullName: string;
		Roles: Models.StringOptionsLookupViewModel[];
		Active: boolean;
	}
	export interface WeatherForecastViewModel
	{
		DateFormatted: string;
		TemperatureC: number;
		TemperatureF: number;
		Summary: string;
	}
}
module Models.PrimeNG.Grid {
	export interface GridPaginator
	{
		First: number;
		Page: number;
		PageCount: number;
		Rows: number;
	}
	export interface GridViewModel<T> extends Models.PrimeNG.Grid.GridPaginator
	{
		Data: T[];
		Errors: string;
		SearchQuery: string;
	}
}
