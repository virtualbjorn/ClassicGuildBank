import { Component, OnInit, Input } from '@angular/core';
import { Character } from 'src/app/models/guildbank/character';
import { ListItem } from 'src/app/models/guildbank/list-item';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ItemClassComparator, ItemSubClassComparator, ItemNameComparator, ItemQuantityComparator } from 'src/app/shared/list-item.comparator';
import { IMoney } from 'src/app/models/guildbank/money.interface';
import { Guild } from 'src/app/models/guildbank/guild';
import { GuildStore } from 'src/app/shared/guild.store';
import { UserStore } from 'src/app/user/user.store';

@Component({
  selector: 'cgb-guild-list',
  templateUrl: './guild-list.component.html',
  styles: []
})
export class GuildListComponent implements OnInit {

  @Input() guild: Guild;
  @Input() characters$: Observable<Character[]>;

  listData$: Observable<ListItem[]>;
  filteredData: ListItem[] = [];

  isUpdatingListItem: boolean = false;

  public classComparator = new ItemClassComparator();
  public subclassComparator = new ItemSubClassComparator();
  public nameComparator = new ItemNameComparator();
  public quantityComparator = new ItemQuantityComparator();

  public guildMoney = {
    gold: 0,
    get goldAmt() { return Math.floor(this.gold / 10000); },
    get silverAmt() { return Math.floor((this.gold / 100) % 100); },
    get copperAmt() { return this.gold % 100; }
  } as IMoney;

  public isReadonly$: Observable<boolean>;
  public userCanUpload$: Observable<boolean>;

  constructor(
    private guildStore: GuildStore,
    private userStore: UserStore
  ) {
    this.isReadonly$ = this.guildStore.isReadonly$;
    this.userCanUpload$ = this.userStore.userCanUpload$;
  }

  ngOnInit() {

    this.listData$ = this.characters$.pipe(map(characters => {

      const itemList: ListItem[] = [];
      this.guildMoney.gold = 0;

      characters.map(c => {
        this.guildMoney.gold += c.gold;

        return c.bags.map(b => b.bagSlots.map(bs => {
          if (!bs.item) return;
          console.log(bs.notes);

          const index = itemList.findIndex(l => l.item.id === bs.item.id);
          let listItem: ListItem;
          if (index < 0) {
            listItem = new ListItem(bs.item);
            itemList.push(listItem);
          } else {
            listItem = itemList[index];
          }

          listItem.quantity += bs.quantity;
          listItem.contributions[c.name] = bs.quantity;
          listItem.notes = bs.notes;
        }));
      });

      return itemList;
    }));

  }

  onFiltered(data: ListItem[]) {
    this.filteredData = data;
  }

  updateListItem(listItem: ListItem) {
    this.isUpdatingListItem = true;
    this.guildStore.updateItemNotes(listItem.item.id, listItem.notes).subscribe({
      next: () => {
        this.isUpdatingListItem = false;
      },
      error: (errorResponse) => {

      }
    });
  }
}
