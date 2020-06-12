export enum GuildUserStatus {
    Online = 0,
    DoNotDisturb,
    Idle,
    Spotify,
    Other
}

export interface SimpleUserInfo {
    name: string;
    nickname: string;
    discriminator: string;
    avatarUrl: string;
    guildUserStatus: GuildUserStatus;
}
