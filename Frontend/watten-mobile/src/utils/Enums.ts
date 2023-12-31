export enum RequestMethod {
  GET = "GET",
  POST = "POST",
  DELETE = "DELETE",
  PUT = "PUT",
}
export enum Mode {
  Add = 0,
  Edit = 1,
}

export enum Language {
  English = "en",
  Arabic = "ar",

  Hebrew = "he",
}

export enum UserRoles {
  Admin = 0,
  Instructor = 1,
  Parent = 2,
}

export enum SessionStatus {
  Available = 0,
  Full = 1,
  Finished = 2,
  Canceled = 3,
}
