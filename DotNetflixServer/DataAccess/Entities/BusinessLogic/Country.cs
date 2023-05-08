﻿namespace DataAccess.Entities.BusinessLogic;

public class Country
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Slug { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
	public List<CountryMovieInfo> Movies { get; set; }
}