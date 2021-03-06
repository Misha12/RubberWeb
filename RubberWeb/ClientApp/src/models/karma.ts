import { SimpleUserInfo } from './users';

export interface KarmaItem {
    user: SimpleUserInfo;
    karma: number;
    positive: number;
    negative: number;
    position: number;
}
