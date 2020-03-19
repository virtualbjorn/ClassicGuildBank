import { Item } from "./item";

export class BagSlot {
    public slotId: number;
    public bagId: number;
    public quantity: number;
    public item?: Item;
    public notes?: string;

    constructor(init?: Partial<BagSlot>) {

        if (init) {
            Object.assign(this, init);
        }
    }
}