import { PageContainer } from '@ant-design/pro-layout';
import { Table, message, Tag, Button, Popconfirm } from 'antd';
import { SyncOutlined, MinusCircleOutlined } from '@ant-design/icons';
import { getMission, delMission, onOff } from './service';
import React, { useState, useEffect } from 'react';
import moment from 'moment';
import AddUpdateMisson from './components/AddUpdateMisson';
import { IMissionInfo } from './typings';

const MissionPage: React.FC = () => {
  const columns = [
    { title: 'Name', dataIndex: 'name' },
    {
      title: 'Type',
      dataIndex: 'type',
      render: (text: number) => {
        let color = 'blue';
        let textStr = 'Token';
        switch (text) {
          case 1: color = 'gold'; textStr = 'Contract'; break;
          case 2: color = 'green'; textStr = 'Wallet'; break;
          default: break;
        }
        return <Tag color={color}>{textStr}</Tag>;
      }
    },
    { title: 'Address', dataIndex: 'collectAddress' },
    { title: 'Interval', dataIndex: 'collectInterval' },
    { title: 'Description', dataIndex: 'describe' },
    {
      title: 'LastCollectTime',
      dataIndex: 'lastCollectTime',
      render: (text: string) => {
        if (text) {
          return moment(text).format(dateTimeStr);
        } else {
          return '--';
        }
      }
    },
    {
      title: 'Status',
      dataIndex: 'status',
      render: (text: number, record: IMissionInfo) => {
        let color = 'default';
        let textStr = 'Stop';
        let icon = <MinusCircleOutlined />;
        switch (text) {
          case 1: icon = <SyncOutlined spin />; color = 'processing'; textStr = 'Running'; break;
          default: break;
        }
        return <Tag icon={icon} color={color}
          onClick={() => turn(record.id)}>
          {textStr}
        </Tag>;
      }
    },
    {
      title: 'Action',
      render: (_text: string, record: IMissionInfo) => {
        return <div>
          <Popconfirm title="Are you sure to delete this task?"
            onConfirm={() => del(record.id)}
            okText="Yes"
            cancelText="No"
          >
            <Button type='link'>Del</Button>
          </Popconfirm>

          <AddUpdateMisson formType='update' missionInfo={record} refresh={() => fetchData()} />
        </div>
      }
    }
  ];

  const [mission, setMission] = useState(initArr);

  const fetchData = async () => {
    const res = await getMission();
    if (res.statusCode === 200) {
      setMission(res.data);
    } else {
      message.error('Fetch Error :' + res?.errors);
    }
  }

  useEffect(() => {
    fetchData();
  }, []);

  const del = async (id: number) => {
    const result = await delMission(id);
    if (result.succeeded) {
      message.success('delelte success');
      fetchData();
    } else {
      message.error('Delelte Failed');
    }
  }

  const turn = async (id: number) => {
    const result = await onOff(id);
    if (result.succeeded) {
      fetchData();
    } else {
      message.error('Turn Failed');
    }
  }

  return (
    <PageContainer>
      <div>
        <AddUpdateMisson formType='add' refresh={() => fetchData()} />
      </div>
      <div style={{ marginTop: 20 }}>
        <Table columns={columns} dataSource={mission} />
      </div>
    </PageContainer>
  )
}

export default MissionPage;
