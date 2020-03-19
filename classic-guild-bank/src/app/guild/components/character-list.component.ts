import { Component, OnInit, Input } from '@angular/core';
import { Character } from 'src/app/models/guildbank/character';
import { ListItem } from 'src/app/models/guildbank/list-item';
import { ItemClassComparator, ItemSubClassComparator, ItemNameComparator, ItemQuantityComparator } from 'src/app/shared/list-item.comparator';
import { Observable } from 'rxjs';
import { GuildStore } from 'src/app/shared/guild.store';
import { UserStore } from 'src/app/user/user.store';

@Component({
  selector: 'cgb-character-list',
  templateUrl: './character-list.component.html',
  styles: []
})
export class CharacterListComponent implements OnInit {

  @Input() character: Character;

  public listData: ListItem[];
  filteredData: ListItem[] = [];

  isUpdatingListItem: boolean = false;

  public classComparator = new ItemClassComparator();
  public subclassComparator = new ItemSubClassComparator();
  public nameComparator = new ItemNameComparator();
  public quantityComparator = new ItemQuantityComparator();

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
    this.listData = [];
    this.character.bags.forEach(bag => {
      bag.bagSlots.forEach(bs => {

        if (!bs.item) return;

        const index = this.listData.findIndex(l => l.item.id === bs.item.id);
        let listItem: ListItem;
        if (index < 0) {
          listItem = new ListItem(bs.item);
          this.listData.push(listItem);
        }
        else listItem = this.listData[index];

        listItem.quantity += bs.quantity;
        listItem.notes = bs.notes;

      })
    });

  }

  onFiltered(data) {
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
