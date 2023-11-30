begin
	insert into dbo.tblApplication (id, Name, Size, ParentId)
	values
	(1, 'Microsoft Word', 10.25, 1),
	(2, 'Freecell', 3, 1),
	(3, 'Steam', 1024,1),
	(4, 'Visual Studio', 2048, 2),
	(5, 'Solitaire', 12.4, 2),
	(6, 'Call of Duty', 4096,2),
	(7, 'Rouvy', 96,2)

end