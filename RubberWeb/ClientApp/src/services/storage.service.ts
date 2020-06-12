import { Injectable } from '@angular/core';

export type StorageType = 'local' | 'session';

@Injectable({ providedIn: 'root' })
export class StorageService {
    store(key: string, value: string, type: StorageType = 'local') {
        const storage = this.getStorage(type);
        storage.setItem(key, value);
    }

    get(key: string, type: StorageType = 'local'): string {
        const storage = this.getStorage(type);
        return storage.getItem(key);
    }

    private getStorage(type: StorageType) {
        if (type === 'local') {
            return localStorage;
        }

        return sessionStorage;
    }
}
