using Tactical.Monopoly.Domain.Boards.Entities;
using Tactical.Monopoly.Domain.Boards.Enums;

namespace Tactical.Monopoly.Domain.Boards.Factories
{
    public class CellFactory
    {
        public static List<Cell> Create(Guid boardId, List<Guid> playerIds)
        {
            var cells = new List<Cell>();

            var start = new Cell(boardId, "Start", 0, Group.NoColor, 0, false, false, 0);
            start.SetStartCell(playerIds);

            var tehran = new Cell(boardId, "Tehran", 1, Group.Blue, 280, true, true, 80);

            var karaj = new Cell(boardId, "Karaj", 2, Group.Blue, 280, true, true, 80);

            var waterCompany = new Cell(boardId, "WaterCompany", 3, Group.Infrastructure, 120, true, false, 0);

            var saary = new Cell(boardId, "Saary", 4, Group.Purple, 220, true, true, 80);

            //TODO Create random Function
            var random1 = new Cell(boardId, "Random1", 5, Group.Random, 0, false, false, 0);

            var gorgan = new Cell(boardId, "Gorgan", 6, Group.Purple, 220, true, true, 80);

            var rasht = new Cell(boardId, "Rasht", 7, Group.Purple, 220, true, true, 80);

            var rahAhan = new Cell(boardId, "RahAhan", 8, Group.Transport, 100, true, false, 80);

            var tax1 = new Cell(boardId, "Tax1", 9, Group.NoColor, 100, false, false, 0);

            var ahvaz = new Cell(boardId, "Ahvaz", 10, Group.Green, 160, true, true, 0);

            var kerman = new Cell(boardId, "Kerman", 11, Group.Green, 160, true, true, 0);

            var jail = new Cell(boardId, "Jail", 12, Group.NoColor, 80, false, false, 0);

            var yazd = new Cell(boardId, "Yazd", 13, Group.Green, 160, true, true, 0);

            var powerCompany = new Cell(boardId, "PowerCompany", 14, Group.Green, 100, true, false, 0);

            var esfahan = new Cell(boardId, "Esfahan", 15, Group.Orange, 260, true, true, 80);

            var shiraz = new Cell(boardId, "Shiraz", 16, Group.Orange, 260, false, false, 80);

            var random2 = new Cell(boardId, "Random2", 17, Group.Random, 0, false, false, 0);

            var tabriz = new Cell(boardId, "tabriz", 18, Group.LightGreen, 240, true, true, 80);

            var ardabil = new Cell(boardId, "ardabil", 19, Group.LightGreen, 240, true, true, 80);

            var tax2 = new Cell(boardId, "Tax2", 20, Group.NoColor, 120, false, false, 0);

            var khorramAbad = new Cell(boardId, "KhorramAbad", 21, Group.Magenta, 120, true, true, 0);

            var hamedan = new Cell(boardId, "Hamedan", 22, Group.Magenta, 120, true, true, 0);

            var forodgah = new Cell(boardId, "Forodgah", 23, Group.Transport, 120, false, false, 0);


            cells.Add(start);
            cells.Add(tehran);
            cells.Add(karaj);
            cells.Add(waterCompany);
            cells.Add(saary);
            cells.Add(random1);
            cells.Add(gorgan);
            cells.Add(rasht);
            cells.Add(rahAhan);
            cells.Add(tax1);
            cells.Add(ahvaz);
            cells.Add(kerman);
            cells.Add(jail);
            cells.Add(yazd);
            cells.Add(powerCompany);
            cells.Add(esfahan);
            cells.Add(shiraz);
            cells.Add(random2);
            cells.Add(tabriz);
            cells.Add(ardabil);
            cells.Add(tax2);
            cells.Add(khorramAbad);
            cells.Add(hamedan);
            cells.Add(forodgah);

            return cells;

        }
    }
}
