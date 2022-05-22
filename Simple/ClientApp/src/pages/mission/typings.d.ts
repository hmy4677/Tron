export interface IMissionInfo {
  id: number;
  name: string;
  status: number;
  collectAddress: string;
  collectTime: string;
  describe: string;
  collectInterval: number;
  type: number;
  lastCollectTime: string;
}
export interface IMissionResponse extends API.IResponse {
  data: IMissionInfo[];
}

export interface IMissionAddPutInfo {
  type: number;
  name: string;
  collectAddress: string;
  coolectInterval: number;
  describe: string;
}
