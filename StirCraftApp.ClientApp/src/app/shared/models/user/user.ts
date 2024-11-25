export type User = {
    email: string;
    password: string;
    displayName: string;
    cookId?: number;
    roles: string[];
};