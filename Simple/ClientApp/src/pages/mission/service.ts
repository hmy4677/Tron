import { request } from 'umi';
import { IMissionResponse, IMissionAddPutInfo } from './typings';

export const getMission = async () => {
  const result = await request<IMissionResponse>('/api/mission/');
  return result;
}

export const addMission = async (data: IMissionAddPutInfo) => {
  return await request<API.IResponse>('/api/mission/', { data: data, method: 'POST' });
}

export const delMission = async (id: number) => {
  return await request<API.IResponse>(`/api/mission/${id}`, { method: 'DELETE' });
}

export const onOff = async (id: number) => {
  return request<API.IResponse>(`/api/mission/${id}`, { method: 'PATCH' });
}

export const putMission = async (id: number, data: IMissionAddPutInfo) => {
  return request<API.IResponse>(`/api/mission/${id}`, {
    method: 'PUT',
    data: data
  });
}
