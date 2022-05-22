import ProForm, { ModalForm, ProFormSelect, ProFormText, ProFormTextArea, ProFormDigit } from '@ant-design/pro-form';
import { Button, message } from 'antd';
import { PlusOutlined } from '@ant-design/icons';
import { addMission, putMission } from '../../service';
import { IMissionAddPutInfo } from '../../typings';

type AddUpdateMissonProps = {
  formType: 'add' | 'update';
  missionInfo?: any;
  refresh: () => void;
}

const AddUpdateMisson: React.FC<AddUpdateMissonProps> = (props) => {
  return (
    <ModalForm title="Mission Info"
      trigger={props.formType === 'add'
        ? <Button icon={<PlusOutlined />} type="primary">Mission </Button>
        : <Button type='link' >Edit</Button>
      }
      autoFocusFirstInput
      initialValues={props?.missionInfo}
      onFinish={async (values: IMissionAddPutInfo) => {
        if (props.formType === 'add') {
          const result = await addMission(values);
          if (result.succeeded) {
            message.success('Add Mission Success');
            props.refresh();
            return true;
          } else {
            message.error('Add Mission Fail');
          }
        } else {
          const result = await putMission(props?.missionInfo?.id, values);
          if (result.succeeded) {
            message.success('Update Mission Success');
            props.refresh();
            return true;
          } else {
            message.error('Update Mission Fail');
          }
        }
      }}
    >
      <ProFormSelect name='type' label='Type'
        required
        options={[
          { label: 'Contract', value: 1 },
          { label: 'Wallet', value: 2 },
          { label: 'Token', value: 3 },
        ]} />
      <ProFormText name='name' label='Name' required />
      <ProFormText name='collectAddress' label='CollectAddress' required />
      <ProFormDigit name='collectInterval' label='CollectInterval' min={0} max={10000} fieldProps={{ precision: 0 }} required />
      <ProFormTextArea name='descpribe' label='Description' />
    </ModalForm >
  );
}

export default AddUpdateMisson;
