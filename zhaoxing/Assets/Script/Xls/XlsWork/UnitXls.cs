
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;
using OfficeOpenXml;
using UnityEditor;


public class UnitXls : MonoBehaviour
{
    public static MostData_SO mostData_So;
    [MenuItem("Excel/Read Excel")]
    public static void ReadMostExcel()
    {
        mostData_So = Resources.Load<MostData_SO>("SO/MostData_SO");
        if (mostData_So == null)
        {
            Debug.Log("����ʧ��" + mostData_So);
        }
        Dictionary<int, IndividualData> dic = LoadExcelAsDictionary(6, Application.dataPath + "/Excel/MostData.xlsx");
        foreach (var item in dic)
        {

            MostData most = mostData_So.mostdataList.Find(i => i.Id == item.Key);
            IndividualData individualData = item.Value;
            if (most != null)
            {
                most.Id = item.Key;
                most.hp = Convert.ToSingle(individualData.Values[1].ToString());
                most.potralSpeed = Convert.ToSingle(individualData.Values[2].ToString());
                most.rushSpeed = Convert.ToSingle(individualData.Values[3].ToString());
                most.dashforce = Convert.ToSingle(individualData.Values[4].ToString());
                most.hitforce = Convert.ToSingle(individualData.Values[5].ToString());
            }
            else
            {
                most = new MostData();
                most.Id = item.Key;
                most.hp = Convert.ToSingle(individualData.Values[1].ToString());
                most.potralSpeed = Convert.ToSingle(individualData.Values[2].ToString());
                most.rushSpeed = Convert.ToSingle(individualData.Values[3].ToString());
                most.dashforce = Convert.ToSingle(individualData.Values[4].ToString());
                most.hitforce = Convert.ToSingle(individualData.Values[5].ToString());
                mostData_So.mostdataList.Add(most);
            }
        }
    }
    public static Dictionary<int, IndividualData> LoadExcelAsDictionary(int CountOfAttributes,string path)
    {
        Dictionary<int, IndividualData> ItemDictionary = new Dictionary<int, IndividualData>();//�½��ֵ䣬���ڴ洢����Ϊ��λ�ĸ���������Ԫ


        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);//�����ļ���fs
        
        ExcelPackage excel = new ExcelPackage(fs);

        ExcelWorksheets workSheets = excel.Workbook.Worksheets;//��ȡȫ��������

        ExcelWorksheet workSheet = workSheets[0];//ֻ����һ�����������߲���
        if (workSheet.Dimension == null)
        {
            Debug.Log("11111");
        }
        int colCount = workSheet.Dimension.End.Column;//�����������
        int rowCount = workSheet.Dimension.End.Row;//�����������

        for (int row = 2; row <= rowCount; row++)//�ӵ�ǰ������ĵڶ��б��������һ��(��һ���Ǳ�ͷ�����Բ���ȡ)
        {
            IndividualData item = new IndividualData(CountOfAttributes);//�½�һ��������Ԫ����ʼ���ձ�������

            for (int col = 1; col <= colCount; col++)//�ӵ�һ�б��������һ��
            {
                //��ȡÿ����Ԫ���е�����
                item.Values[col - 1] = workSheet.Cells[row, col].Text;//����Ԫ���е�����д�������Ԫ
            }

            int itemID = Convert.ToInt32(item.Values[0].ToString());//��ȡ������Ԫ��ID

            ItemDictionary.Add(itemID, item);//��ID�Ͳ�����Ԫд���ֵ�
        }

       
        return ItemDictionary;
    }

    
}
